#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System.Linq;
    using UnityEditor;
    using UnityEditor.PackageManager;
    using UnityEditor.PackageManager.Requests;
    using UnityEngine;

    static class OpenProcess
    {
        private static AddRequest _currentAddRequest;
        
        private const string XR_PACKAGE_NAME = "com.unity.xr.management";
        private const string OCULUS_PACKAGE_NAME = "com.unity.xr.oculus";
        private const string URP_PACKAGE_NAME = "com.unity.render-pipelines.universal";
        private const string HDRP_PACKAGE_NAME = "com.unity.render-pipelines.high-definition";
        
        private static int _retryCount;
        private const int maxRetryCount = 10;

        private const string CURRENT_STATE_KEY = "PackageInstallState";
        private enum PackageInstallState
        {
            None,
            InstallingXR,
            InstallingOculus,
            InstallingURP,
            InstallingHDRP
        }

        [InitializeOnLoadMethod]
        public static void Init()
        {
            if (!Application.isBatchMode) return;
            
            Events.registeredPackages -= PackageWasRegistered;
            Events.registeredPackages += PackageWasRegistered;

            // Check if we were in the process of installing any package and resume the monitor
            if (CurrentInstallState != PackageInstallState.None)
            {
                EditorApplication.update += Monitor;
            }
        }

        public static void PackageWasRegistered(PackageRegistrationEventArgs args)
        {
            CurrentInstallState = PackageInstallState.None;
        }

        public static void CheckForVRSupport()
        {
            try
            {
                EditorApplication.update -= Monitor;
                EditorApplication.update += Monitor;

                _retryCount = 0;

                var packageList = Client.List(true);
                while (!packageList.IsCompleted) { }

                if (!IsPackageInstalled(packageList, XR_PACKAGE_NAME))
                {
                    CurrentInstallState = PackageInstallState.InstallingXR;
                    AddPackage(XR_PACKAGE_NAME);
                    return;
                }

                if (!IsPackageInstalled(packageList, OCULUS_PACKAGE_NAME))
                {
                    CurrentInstallState = PackageInstallState.InstallingOculus;
                    AddPackage(OCULUS_PACKAGE_NAME);
                    return;
                }
            
                EditorApplication.update -= Monitor;
                EditorApplication.Exit(0);
            }
            catch
            {
                EditorApplication.Exit(1);
            }
        }

        public static void CheckForURP()
        {
            try
            {
                EditorApplication.update -= Monitor;
                EditorApplication.update += Monitor;

                _retryCount = 0;
                
                var packageList = Client.List(true);
                while (!packageList.IsCompleted) { }

                if (!IsPackageInstalled(packageList, URP_PACKAGE_NAME))
                {
                    CurrentInstallState = PackageInstallState.InstallingURP;
                    AddPackage(URP_PACKAGE_NAME);
                    return;
                }
                
                EditorApplication.update -= Monitor;
                EditorApplication.Exit(0);
            }
            catch
            {
                EditorApplication.Exit(1);
            }
        }
        
        public static void CheckForHDRP()
        {
            try
            {
                EditorApplication.update -= Monitor;
                EditorApplication.update += Monitor;

                _retryCount = 0;
                
                var packageList = Client.List(true);
                while (!packageList.IsCompleted) { }

                if (!IsPackageInstalled(packageList, HDRP_PACKAGE_NAME))
                {
                    CurrentInstallState = PackageInstallState.InstallingHDRP;
                    AddPackage(HDRP_PACKAGE_NAME);
                    return;
                }
                
                EditorApplication.update -= Monitor;
                EditorApplication.Exit(0);
            }
            catch
            {
                EditorApplication.Exit(1);
            }
        }

        private static bool IsPackageInstalled(ListRequest packageList, string packageName)
        {
            return packageList.Result.Any(p => p.name == packageName);
        }

        private static void AddPackage(string packageName)
        {
            _currentAddRequest = Client.Add(packageName);
        }

        private static void Monitor()
        {
            if (_currentAddRequest == null)
            {
                if (CurrentInstallState == PackageInstallState.None)
                {
                    EditorApplication.update -= Monitor;
                    EditorApplication.Exit(0);
                }
                return;
            }

            if (_currentAddRequest.Status == StatusCode.InProgress)
            {
                return;
            }

            if (_currentAddRequest.Status == StatusCode.Success)
            {
                UnityEngine.Debug.Log($"{_currentAddRequest.Result.name} installed successfully!");
                _currentAddRequest = null;
                if (CurrentInstallState is PackageInstallState.InstallingOculus or PackageInstallState.InstallingXR)
                {
                    CheckForVRSupport();
                }
            }
            else if (_currentAddRequest.Status >= StatusCode.Failure)
            {
                _retryCount++;

                if (_retryCount > maxRetryCount)
                {
                    UnityEngine.Debug.LogError($"Failed to add package after {_retryCount} attempts. Exiting.");
                    EditorApplication.update -= Monitor;
                    CurrentInstallState = PackageInstallState.None;
                    EditorApplication.Exit(1); // Exit with error code
                }
                else
                {
                    UnityEngine.Debug.LogError($"Failed to install package {_currentAddRequest.Result.name}. Retrying attempt {_retryCount}...");
                    AddPackage(_currentAddRequest.Result.name);
                }
            }
        }

        private static PackageInstallState CurrentInstallState
        {
            get => (PackageInstallState)SessionState.GetInt(CURRENT_STATE_KEY, (int)PackageInstallState.None);
            set => SessionState.SetInt(CURRENT_STATE_KEY, (int)value);
        }
    }
}
#endif
