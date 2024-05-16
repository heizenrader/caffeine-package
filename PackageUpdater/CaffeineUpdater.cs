#if UNITY_EDITOR && !EDXR_VIEWER
using System;
using System.Collections.Generic;
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
            .Select(v => new { Version = v, Parsed = Version.Parse(Regex.Match(v, @"^\d+(\.\d+)*").Value) })
            .OrderByDescending(v => v.Parsed)
            .Select(v => v.Version)
            .FirstOrDefault();
    }

    public static bool IsHigherVersionAvailable(string currentVersion, IEnumerable<string> versions)
    {
        var currentParsed = Version.Parse(Regex.Match(currentVersion, @"^\d+(\.\d+)*").Value);
        return versions
            .Where(IsStableRelease)
            .Select(v => Version.Parse(Regex.Match(v, @"^\d+(\.\d+)*").Value))
            .Any(v => v > currentParsed);
    }
}

public class CaffeineUpdater : IPackageManagerExtension
{
    private static ListRequest _listRequest;
    private static AddRequest _addRequest;
    private static int _progressId = -1;

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
        if (packageInfo == null || string.IsNullOrEmpty(packageInfo.name)) return;

        var packageName = packageInfo.name.ToLower();
        if (packageName.Contains("caffeine"))
        {
            RemovePackageSymLinksFromCaffeineBuilders();
        }
    }

    public void OnPackageRemoved(PackageInfo packageInfo)
    {
        if (packageInfo == null || string.IsNullOrEmpty(packageInfo.name)) return;

        var packageName = packageInfo.name.ToLower();
        if (packageName.Contains("caffeine"))
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
                        var highestVersion = VersionUtility.GetHighestStableVersion(allVersions);

                        if (!string.IsNullOrEmpty(latestCompatibleVersion) && new Version(latestCompatibleVersion) > new Version(currentVersion))
                        {
                            var shouldUpdate = EditorUtility.DisplayDialog("Package Update", $"There is an update available for {package.displayName}. Would you like to update to version {latestCompatibleVersion}?", "Ok", "Cancel");
                            if (shouldUpdate)
                            {
                                RemovePackageSymLinksFromCaffeineBuilders();
                                var updateToPackage = $"{package.name}@{latestCompatibleVersion}";
                                _progressId = Progress.Start($"Updating {package.displayName}...");
                                _addRequest = Client.Add(updateToPackage);

                                EditorApplication.update += UpdatePackage;
                            }
                        }
                        else if (VersionUtility.IsHigherVersionAvailable(currentVersion, allVersions))
                        {
                            EditorUtility.DisplayDialog("Package Update", $"There is an update available for {package.displayName}. Please upgrade to Unity 2022.3.20f1. ", "Ok");
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
    
    private static void RemovePackageSymLinksFromCaffeineBuilders()
    {
        try
        {
            var caffeineAssembly = "Caffeine";
            var className = "Caffeine.BuilderProjectManager";
            var methodName = "RemovePackageSymLinksFromBuilders";

            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == caffeineAssembly);
            if (assembly == null)
            {
                Debug.LogError($"Assembly '{caffeineAssembly}' not found.");
                return;
            }

            Type type = assembly.GetType(className);
            if (type == null)
            {
                Debug.LogError($"Type '{className}' not found in assembly '{caffeineAssembly}'.");
                return;
            }

            MethodInfo method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
            if (method == null)
            {
                Debug.LogError($"Method '{methodName}' not found in type '{className}'.");
                return;
            }

            // Invoke the method
            method.Invoke(null, null);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error invoking method: {ex.Message}");
        }
    }
    
    private static void RemoveCaffeineBuilders()
    {
        try
        {
            var caffeineAssembly = "Caffeine";
            var className = "Caffeine.BuilderProjectManager";
            var methodName = "RemoveBuilderProjects";

            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == caffeineAssembly);
            if (assembly == null)
            {
                Debug.LogError($"Assembly '{caffeineAssembly}' not found.");
                return;
            }

            Type type = assembly.GetType(className);
            if (type == null)
            {
                Debug.LogError($"Type '{className}' not found in assembly '{caffeineAssembly}'.");
                return;
            }

            MethodInfo method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
            if (method == null)
            {
                Debug.LogError($"Method '{methodName}' not found in type '{className}'.");
                return;
            }

            // Invoke the method
            method.Invoke(null, null);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error invoking method: {ex.Message}");
        }
    }
}

#endif