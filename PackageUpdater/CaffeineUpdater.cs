#if UNITY_EDITOR && !EDXR_VIEWER
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

internal static class CaffeineUpdateProgress
{
    private const string K_Status = "CaffeineUpdater.CurrentStatus";
    private const string Title = "Caffeine Update";

    public static void Show(string message)
    {
        SessionState.SetString(K_Status, message);
        EditorUtility.DisplayProgressBar(Title, message, 0.5f);
    }

    public static void Clear()
    {
        SessionState.EraseString(K_Status);
        EditorUtility.ClearProgressBar();
    }

    public static void RestoreIfNeeded()
    {
        var status = SessionState.GetString(K_Status, "");
        if (!string.IsNullOrEmpty(status))
            EditorUtility.DisplayProgressBar(Title, status, 0.5f);
    }
}



[InitializeOnLoad]
public class PackageManagerExtensionRegister
{
    static PackageManagerExtensionRegister()
    {
        if (Application.isBatchMode) return;
        PackageManagerExtensions.RegisterExtension(new CaffeineUpdater());
    }
}

public static class VersionUtility
{
    private static bool IsStableRelease(string version)
    {
        return !version.Contains("-");
    }

    public static string GetHighestStableVersion(IEnumerable<string> versions)
    {
        return versions
            .Where(IsStableRelease)
            .Select(v => new { Version = v, Parsed = ParseUnityVersion(v) })
            .OrderByDescending(v => v.Parsed)
            .Select(v => v.Version)
            .FirstOrDefault();
    }

    public static bool IsHigherVersionAvailable(string currentVersion, IEnumerable<string> versions)
    {
        var currentParsed = ParseUnityVersion(currentVersion);
        return versions
            .Where(IsStableRelease)
            .Select(ParseUnityVersion)
            .Any(v => v > currentParsed);
    }

    public static System.Version ParseUnityVersion(string version)
    {
        // Extract the numeric part of the version string
        var match = Regex.Match(version, @"(\d+)\.(\d+)\.(\d+)");
        if (!match.Success)
        {
            throw new FormatException($"Invalid Unity version format: {version}");
        }

        int major = int.Parse(match.Groups[1].Value);
        int minor = int.Parse(match.Groups[2].Value);
        int build = int.Parse(match.Groups[3].Value);

        return new System.Version(major, minor, build);
    }
}

public class CaffeineUpdater : IPackageManagerExtension
{
    public static event Action UpdateStateChanged;
    
    private static ListRequest _listRequest, _resumeListRequest;
    private static AddRequest _addRequest;
    
    private const string _expectedReleaseVersion = "6000.0.63f1";

    private static int _stableFrames = 0;
    private const int RequiredStableFrames = 10;

    // Single-flight guard
    private static bool _checkQueuedOrRunning;

    // SessionState keys (centralize to avoid typos)
    private const string K_SupportedUpdateAvailable = "SupportedPackageUpdateAvailable";
    private const string K_SupportedVersion = "SupportedPackageVersion";
    private const string K_UnsupportedUpdateAvailable = "UnSupportedPackageUpdateAvailable";
    private const string K_UnityVersionToUpgradeTo = "UnityVersionToUpgradeTo";

    private const string K_CheckInProgress = "CaffeineUpdateCheckInProgress";
    private const string K_CheckFailed = "CaffeineUpdateCheckFailed";
    private const string K_CheckError = "CaffeineUpdateCheckError";
    private const string K_LastCheckUtcTicks = "CaffeineUpdateLastCheckUtcTicks";
    
    private const string K_UpdateInProgress = "CaffeineUpdater.UpdateInProgress";
    private const string K_UpdateTargetVersion = "CaffeineUpdater.UpdateTargetVersion";
    private const string K_UpdateQueuedUtcTicks = "CaffeineUpdater.UpdateQueuedUtcTicks";
    
    [InitializeOnLoadMethod]
    public static void PackageUpdateCheck()
    {
        QueueUpdateCheck(auto: true);
    }

    [MenuItem("Caffeine/Help/Check For Updates")]
    public static void CheckForUpdates()
    {
        QueueUpdateCheck(auto: false);
    }
    
    private static void QueueUpdateCheck(bool auto)
    {
        if (Application.isBatchMode) return;

        // Prevent spamming by multiple triggers (domain reload + menu spam)
        if (_checkQueuedOrRunning) return;
        _checkQueuedOrRunning = true;

        _stableFrames = 0;

        // Reset state for UI
        ResetUpdateStateForNewCheck();

        // Idempotent subscription
        EditorApplication.update -= WaitForEditorStabilityThenRun;
        EditorApplication.update += WaitForEditorStabilityThenRun;
    }
    
    private static void ResetUpdateStateForNewCheck()
    {
        SessionState.SetBool(K_CheckInProgress, true);
        SessionState.SetBool(K_CheckFailed, false);
        SessionState.SetString(K_CheckError, string.Empty);

        SessionState.SetBool(K_SupportedUpdateAvailable, false);
        SessionState.SetString(K_SupportedVersion, string.Empty);

        SessionState.SetBool(K_UnsupportedUpdateAvailable, false);
        SessionState.SetString(K_UnityVersionToUpgradeTo, string.Empty);
    }
    
    private static void FinishCheckSuccess()
    {
        SessionState.SetBool(K_CheckInProgress, false);
        SessionState.SetBool(K_CheckFailed, false);
        SessionState.SetString(K_CheckError, string.Empty);
        SessionState.SetString(K_LastCheckUtcTicks, DateTime.UtcNow.Ticks.ToString());
        _checkQueuedOrRunning = false;
    }
    
    private static void FinishCheckFailure(string error)
    {
        SessionState.SetBool(K_CheckInProgress, false);
        SessionState.SetBool(K_CheckFailed, true);
        SessionState.SetString(K_CheckError, error ?? "Unknown error");
        SessionState.SetString(K_LastCheckUtcTicks, DateTime.UtcNow.Ticks.ToString());
        _checkQueuedOrRunning = false;
    }

    private static void WaitForEditorStabilityThenRun()
    {
        if (EditorApplication.isCompiling || EditorApplication.isUpdating || EditorApplication.isPlayingOrWillChangePlaymode)
        {
            _stableFrames = 0;
            return;
        }

        _stableFrames++;
        if (_stableFrames < RequiredStableFrames) return;
        
        // Overwrite Previous Dismissal Flag
        SessionState.SetBool("Caffeine.UpdateBanner.Dismissed", false);
        
        EditorApplication.update -= WaitForEditorStabilityThenRun;

        // Kick list request (single request at a time)
        try
        {
            _listRequest = Client.List();

            // Idempotent subscription
            EditorApplication.update -= PackageRequestUpdate;
            EditorApplication.update += PackageRequestUpdate;
        }
        catch (Exception e)
        {
            FinishCheckFailure(e.Message);
        }
    }

    public VisualElement CreateExtensionUI()
    {
        // Ignored
        return null;
    }

    public void OnPackageSelectionChange(PackageInfo packageInfo)
    {
        //throw new System.NotImplementedException();
    }
    
    [InitializeOnLoadMethod]
    private static void ResumeUpdateIfNeeded()
    {
        // Exit If Builder
        if (Application.isBatchMode) return;

        // Exit If Not In Progress
        if (!SessionState.GetBool(K_UpdateInProgress, false)) return;

        // If we were mid-update and Unity reloaded, restore the progress UI
        CaffeineUpdateProgress.RestoreIfNeeded();

        // Continue on next tick so editor is initialized
        EditorApplication.delayCall -= ResumeOrCompleteUpdateFlow;
        EditorApplication.delayCall += ResumeOrCompleteUpdateFlow;
    }

    public static void InstallSupportedUpdate()
    {
        // Exit If Builder
        if (Application.isBatchMode) return;

        // If already in progress, just restore UI and bail.
        if (SessionState.GetBool(K_UpdateInProgress, false))
        {
            CaffeineUpdateProgress.RestoreIfNeeded();
            return;
        }

        bool supportedUpdate = SessionState.GetBool(K_SupportedUpdateAvailable, false);
        if (!supportedUpdate)
        {
            EditorUtility.DisplayDialog("Caffeine Update", "No supported Caffeine update is currently available for this Unity version.", "Ok");
            return;
        }

        string targetVersion = SessionState.GetString(K_SupportedVersion, string.Empty);
        if (string.IsNullOrEmpty(targetVersion))
        {
            EditorUtility.DisplayDialog("Caffeine Update", "Could not determine the target version for this update.", "Ok");
            return;
        }

        // Mark in progress so we can resume on domain reload.
        SessionState.SetBool(K_UpdateInProgress, true);
        SessionState.SetString(K_UpdateTargetVersion, targetVersion);
        SessionState.SetString(K_UpdateQueuedUtcTicks, DateTime.UtcNow.Ticks.ToString());

        NotifyStateChanged();

        // Immediate user feedback before UPM starts showing anything.
        CaffeineUpdateProgress.Show("Preparing package update...");

        // Start add request on delayCall (safer than doing it inside a UI click call stack)
        EditorApplication.delayCall -= StartAddRequestForTargetVersion;
        EditorApplication.delayCall += StartAddRequestForTargetVersion;
    }
    
    private static void StartAddRequestForTargetVersion()
    {
        if (!SessionState.GetBool(K_UpdateInProgress, false)) return;

        string targetVersion = SessionState.GetString(K_UpdateTargetVersion, string.Empty);
        if (string.IsNullOrEmpty(targetVersion))
        {
            FailUpdate("Missing target version.");
            return;
        }

        try
        {
            CaffeineUpdateProgress.Show("Requesting package update from UPM...");

            // Request specific version that was detected
            string packageId = $"com.caffeine@{targetVersion}";
            _addRequest = Client.Add(packageId);

            // Poll for completion
            EditorApplication.update -= UpdateAddRequestProgress;
            EditorApplication.update += UpdateAddRequestProgress;
        }
        catch (Exception e)
        {
            FailUpdate(e.Message);
        }
    }

    private static void UpdateAddRequestProgress()
    {
        if (_addRequest is not { IsCompleted: true }) return;

        try
        {
            if (_addRequest.Status == StatusCode.Success)
            {
                var installedVersion = _addRequest.Result?.version ?? SessionState.GetString(K_UpdateTargetVersion, "");
                Debug.Log($"Successfully updated com.caffeine to {installedVersion}");

                CompleteUpdateSuccess();
            }
            else
            {
                var msg = _addRequest.Error?.message ?? "Unknown error.";
                Debug.LogError($"Failed to update com.caffeine: {msg}");
                FailUpdate(msg);
            }
        }
        finally
        {
            EditorApplication.update -= UpdateAddRequestProgress;
            _addRequest = null;
        }
    }

    private static void ResumeOrCompleteUpdateFlow()
    {
        if (!SessionState.GetBool(K_UpdateInProgress, false)) return;

        string targetVersion = SessionState.GetString(K_UpdateTargetVersion, string.Empty);
        if (string.IsNullOrEmpty(targetVersion))
        {
            FailUpdate("Missing target version during resume.");
            return;
        }

        try
        {
            CaffeineUpdateProgress.Show("Resuming package update...");

            _resumeListRequest = Client.List();
            EditorApplication.update -= ResumeListUpdate;
            EditorApplication.update += ResumeListUpdate;
        }
        catch (Exception e)
        {
            FailUpdate(e.Message);
        }
    }

    private static void ResumeListUpdate()
    {
        if (_resumeListRequest == null || !_resumeListRequest.IsCompleted) return;

        try
        {
            if (_resumeListRequest.Status != StatusCode.Success)
            {
                FailUpdate(_resumeListRequest.Error?.message ?? "Failed to list packages while resuming update.");
                return;
            }

            var caffeine = _resumeListRequest.Result.FirstOrDefault(p => p.name == "com.caffeine");
            var targetVersion = SessionState.GetString(K_UpdateTargetVersion, "");

            // If already installed, finish cleanly
            if (caffeine != null && !string.IsNullOrEmpty(caffeine.version))
            {
                var installed = VersionUtility.ParseUnityVersion(caffeine.version);
                var target = VersionUtility.ParseUnityVersion(targetVersion);

                if (installed >= target)
                {
                    CompleteUpdateSuccess();
                    return;
                }
            }

            // Otherwise, start the add request again (idempotent enough for UPM)
            StartAddRequestForTargetVersion();
        }
        finally
        {
            EditorApplication.update -= ResumeListUpdate;
            _resumeListRequest = null;
        }
    }


    private static void CompleteUpdateSuccess()
    {
        SessionState.SetBool(K_UpdateInProgress, false);
        SessionState.SetString(K_UpdateTargetVersion, string.Empty);
        SessionState.SetString(K_UpdateQueuedUtcTicks, string.Empty);

        // Clear the "supported update available" state (it should now be installed).
        SessionState.SetBool(K_SupportedUpdateAvailable, false);
        SessionState.SetString(K_SupportedVersion, string.Empty);

        CaffeineUpdateProgress.Clear();

        NotifyStateChanged();
    }

    private static void FailUpdate(string error)
    {
        SessionState.SetBool(K_UpdateInProgress, false);
        // Keep SupportedUpdateAvailable intact so user can try again

        CaffeineUpdateProgress.Clear();

        NotifyStateChanged();

        EditorUtility.DisplayDialog("Caffeine Update Failed", $"Caffeine update failed.\n\n{error}", "Ok");
    }


    public void OnPackageAddedOrUpdated(PackageInfo packageInfo)
    {
        if (Application.isBatchMode) return;
        if (packageInfo == null || string.IsNullOrEmpty(packageInfo.name) || packageInfo.name.ToLower() != "com.caffeine") return;
        
        var info = new Caffeine.Package.PackageInfo()
        {
            PackageName = packageInfo.name.ToLower(),
            PackageID = packageInfo.packageId,
            PackagePath = packageInfo.resolvedPath
        };

        try
        {
            var jsonInfo = JsonUtility.ToJson(info);
            if (!string.IsNullOrEmpty(jsonInfo))
            {
                var path = Path.Combine(Application.persistentDataPath, "Package.info");
                File.WriteAllText(path, jsonInfo);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception Saving Package Info: " + e.Message);
        }
            
        SessionState.SetBool("ReLinkPackage", true);
    }

    public void OnPackageRemoved(PackageInfo packageInfo)
    {
        if (packageInfo == null || string.IsNullOrEmpty(packageInfo.name)) return;

        var packageName = packageInfo.name.ToLower();
        if (packageName.Contains("com.caffeine"))
        {
            RemoveCaffeineBuilders();
        }
    }
    
    private static void PackageRequestUpdate()
    {
        if (_listRequest == null || !_listRequest.IsCompleted) return;

        try
        {
            switch (_listRequest.Status)
            {
                case StatusCode.Success:
                {
                    bool foundCaffeine = false;

                    foreach (var package in _listRequest.Result)
                    {
                        if (!package.name.ToLower().StartsWith("com.caffeine"))
                            continue;

                        foundCaffeine = true;

                        string currentVersion = package.version;
                        var compatibleVersions = package.versions.compatible;
                        var allVersions = package.versions.all;

                        var latestCompatibleVersion = VersionUtility.GetHighestStableVersion(compatibleVersions);

                        if (!string.IsNullOrEmpty(latestCompatibleVersion) && VersionUtility.ParseUnityVersion(latestCompatibleVersion) > VersionUtility.ParseUnityVersion(currentVersion))
                        {
                            SessionState.SetString(K_SupportedVersion, latestCompatibleVersion);
                            SessionState.SetBool(K_SupportedUpdateAvailable, true);

                            // Ensure opposite flag is cleared
                            SessionState.SetBool(K_UnsupportedUpdateAvailable, false);
                            SessionState.SetString(K_UnityVersionToUpgradeTo, string.Empty);

                            EditorUtility.DisplayDialog(
                                "Notification",
                                "A Caffeine package update is available. Please check the Caffeine Window for more information.",
                                "Ok"
                            );
                        }
                        else if (VersionUtility.IsHigherVersionAvailable(currentVersion, allVersions))
                        {
                            SessionState.SetString(K_UnityVersionToUpgradeTo, _expectedReleaseVersion);
                            SessionState.SetBool(K_UnsupportedUpdateAvailable, true);

                            // Ensure opposite flag is cleared
                            SessionState.SetBool(K_SupportedUpdateAvailable, false);
                            SessionState.SetString(K_SupportedVersion, string.Empty);
                            
                            EditorUtility.DisplayDialog(
                                "Notification",
                                "A Caffeine package update is available. Please check the Caffeine Window for more information.",
                                "Ok"
                            );
                        }

                        break;
                    }
                    
                    // Notify of potential changes
                    NotifyStateChanged();

                    // If caffeine not found, it might not be installed; treat as success but no update.
                    FinishCheckSuccess();
                    break;
                }

                default:
                    FinishCheckFailure(_listRequest.Error?.message ?? "Failed to list packages.");
                    Debug.LogError($"Failed to list packages: {_listRequest.Error?.message}");
                    break;
            }
        }
        finally
        {
            EditorApplication.update -= PackageRequestUpdate;
        }
    }
    
    private static void NotifyStateChanged()
    {
        UpdateStateChanged?.Invoke();
    }
    
    private static void RemoveCaffeineBuilders()
    {
        // TO:DO Replace Reflection And Just Remove Builders
        // Look For Builders Folder And Remove / With Some Verification
    }
    
    public static void Debug_NotifyStateChanged()
    {
        UpdateStateChanged?.Invoke();
    }
}

#endif