/*#if UNITY_EDITOR && !EDXR_VIEWER
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;


[InitializeOnLoad]
public class PackageManagerExtensionRegister
{
    static PackageManagerExtensionRegister()
    {
        PackageManagerExtensions.RegisterExtension(new CaffeineUpdater());
    }
}

public static class VersionUtility
{
    public static bool IsStableRelease(string version)
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
    private static ListRequest _listRequest;
    private static AddRequest _addRequest;
    private static int _progressId = -1;
    private const string _expectedReleaseVersion = "2022.3.54f1";

    [InitializeOnLoadMethod]
    public static void PackageUpdateCheck()
    {
        EditorApplication.delayCall += () =>
        {
            if (Application.isBatchMode) { return; }

            _listRequest = Client.List();
            EditorApplication.update += PackageRequestUpdate;
        };
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

    private static void UpdatePackage()
    {
        if (!_addRequest.IsCompleted) return;

        if (_addRequest.Status == StatusCode.Success)
        {
            Debug.Log($"Successfully updated package to version {_addRequest.Result.version}");
        }
        else if (_addRequest.Status >= StatusCode.Failure)
        {
            Debug.LogError($"Failed to update package: {_addRequest.Error.message}");
        }

        if (_progressId != -1)
        {
            Progress.Remove(_progressId);
            _progressId = -1;
        }
        
        EditorApplication.update -= UpdatePackage;
    }

    private static void PackageRequestUpdate()
    {
        if (!_listRequest.IsCompleted) return;
        switch (_listRequest.Status)
        {
            case StatusCode.Success:
            {
                foreach (var package in _listRequest.Result)
                {
                    if (package.name.ToLower().StartsWith("com.caffeine"))
                    {
                        string currentVersion = package.version;
                        var compatibleVersions = package.versions.compatible;
                        var allVersions = package.versions.all;
                        var latestCompatibleVersion = VersionUtility.GetHighestStableVersion(compatibleVersions);

                        if (!string.IsNullOrEmpty(latestCompatibleVersion) && VersionUtility.ParseUnityVersion(latestCompatibleVersion) > VersionUtility.ParseUnityVersion(currentVersion))
                        {
                            var shouldUpdate = EditorUtility.DisplayDialog("Package Update", $"There is an update available for {package.displayName}. Would you like to update to version {latestCompatibleVersion}?", "Ok", "Cancel");
                            if (shouldUpdate)
                            {
                                var updateToPackage = $"{package.name}@{latestCompatibleVersion}";
                                _progressId = Progress.Start($"Updating {package.displayName}...");
                                _addRequest = Client.Add(updateToPackage);

                                EditorApplication.update += UpdatePackage;
                            }
                        }
                        else if (VersionUtility.IsHigherVersionAvailable(currentVersion, allVersions))
                        {
                            EditorUtility.DisplayDialog("Package Update", $"There is an update available for {package.displayName}. Please upgrade to Unity {_expectedReleaseVersion}. ", "Ok");
                        }

                        break;
                    }
                }

                break;
            }
            case >= StatusCode.Failure:
                Debug.LogError($"Failed to list packages: {_listRequest.Error.message}");
                break;
        }

        EditorApplication.update -= PackageRequestUpdate;
    }
    
    private static void RemoveCaffeineBuilders()
    {
        // TO:DO Replace Reflection And Just Remove Builders
        // Look For Builders Folder And Remove / With Some Verification
    }
}

#endif*/