#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Build;
    using Build.Process;
    using Build.Session;
    using UnityEditor;
    using UnityEditor.PackageManager;
    using UnityEditor.PackageManager.Requests;
    using UnityEngine;
    using UnityEngine.Rendering;
    using Caffeine.RenderPipeline;
    using Stopwatch = System.Diagnostics.Stopwatch;

    [InitializeOnLoad]
    public class PackagePass
    {
        private static int _framesToWait = 3;
        public const string kPackagePassCallBack = "PackagePassCallback";
        public const string kVisionOSPackageName = "com.unity.xr.visionos";
        public const string kURPPackageName = "com.unity.render-pipelines.universal";
        public const string kHDRPPackageName = "com.unity.render-pipelines.high-definition";

        static PackagePass()
        {
            var pendingPackageCallback = SessionState.GetString(kPackagePassCallBack, null);
            if (string.IsNullOrEmpty(pendingPackageCallback)) return;

            _framesToWait = 3;
            EditorApplication.update -= WaitUntilIdle;
            EditorApplication.update += WaitUntilIdle;
        }
        
        /// <summary>
        /// Main entry point for batch builds. Always call this from your executeMethod.
        /// </summary>
        public static void Begin()
        {
            // Store the callback we want to eventually invoke (PackagePass.Start)
            SessionState.SetString(kPackagePassCallBack, $"{typeof(PackagePass).FullName}.{nameof(Start)}");

            // Schedule WaitUntilIdle in the *current* domain
            _framesToWait = 3;
            EditorApplication.update -= WaitUntilIdle;
            EditorApplication.update += WaitUntilIdle;
        }
        
        static void WaitUntilIdle()
        {
            if (EditorApplication.isCompiling || EditorApplication.isUpdating || AssetDatabase.IsAssetImportWorkerProcess())
                return;

            if (--_framesToWait > 0)
                return;

            EditorApplication.update -= WaitUntilIdle;
            
            var pendingPackageCallback = SessionState.GetString(kPackagePassCallBack, null);
            if (string.IsNullOrEmpty(pendingPackageCallback)) return;
            
            SessionState.SetString(kPackagePassCallBack, null);
            InvokeStoredMethod(pendingPackageCallback);
        }
        
        private static ListRequest _listRequest;
        private static AddRequest _addRequest;
        private static RemoveRequest _removeRequest;
        
        public static void Start()
        {
            Debug.Log("C003 - Start - Package Pass, Ensuring Required Packages Are Installed And/Or Set ");

            // If VisionOS Platform Ensure VisionOS Package Is Installed Before Passing Package Checks
            if (SessionManager.IsVisionOS && !SessionManager.VisionOSPackageInstalled)
            {
                CheckForVisionOSPackageInstallation();
                return;
            }
            
            // Verify Pipeline Package For Current Build
            if (!SessionManager.RenderPipelinePass)
            {
                CheckForRenderPipelinePackageInstallation();
                return;
            }
            
            // 3 - Start Import Of Unity Scene Package ( Resuming From Import Process )
            if (!string.IsNullOrEmpty(SessionManager.PackageScenePath))
            {
                LogImmediate($"Importing Scene Package");
                SessionManager.PackageImporting = true;
                Debug.Log("C003.1 - Start - Package Pass Completed Proceeding With Scene Unity Package Import Process");

                PackageImporter.ImportPackageInStages(SessionManager.PackageScenePath);
            }
        }
        
        public static void CheckForVisionOSPackageInstallation()
        {
            LogImmediate("VisionOS Package Verification");
            
            _listRequest = Client.List();
            EditorApplication.update -= OnListRequestUpdateForVisionOS;
            EditorApplication.update += OnListRequestUpdateForVisionOS;
        }
        
        public static void CheckForRenderPipelinePackageInstallation()
        {
            LogImmediate("RenderPipeline Package Verification");

            _listRequest = Client.List();
            EditorApplication.update -= OnListRequestUpdateForRenderPipelines;
            EditorApplication.update += OnListRequestUpdateForRenderPipelines;
        }

        public static void VisionOSCheckFinished()
        {
            if (!SessionManager.VisionOSPackageInstalled)
            {
                // Install Missing VisionOS Package
                InstallRequiredVisionOSPackage(GetCallbackString<PackagePass>(nameof(VisionOSPackageInstalled)));                
            }
            else
            {
                // Resume Flow VisionOS Package Is Installed
                Start();
            }
        }

        public static void RenderPipelineCheckFinished()
        {
            if (SessionManager.RenderPipelinePass) return;

            var pipeline = SessionManager.RenderPipeline;
            var isBuiltIn = string.IsNullOrEmpty(pipeline) || pipeline == "STANDARD";

            if (isBuiltIn)
            {
                // Using Built-in: remove URP/HDRP and clear graphics settings
                if (SessionManager.URPPackageInstalled)
                {
                    EmitPhase(Caffeine.Editor.Build.Protocol.BuildPhases.ConvergeStart);
                    LogImmediate("URP Package Removal");
                    SessionManager.URPPackageInstalled = false;
                    RemoveURPPackage(GetCallbackString<PackagePass>(nameof(RenderPipelineCheckFinished)));
                    return;
                }

                if (SessionManager.HDRPPackageInstalled)
                {
                    EmitPhase(Caffeine.Editor.Build.Protocol.BuildPhases.ConvergeStart);
                    LogImmediate("HDRP Package Removal");
                    SessionManager.HDRPPackageInstalled = false;
                    RemoveHDRPPackage(GetCallbackString<PackagePass>(nameof(RenderPipelineCheckFinished)));
                    return;
                }

                if (GraphicsSettings.defaultRenderPipeline != null)
                {
                    LogImmediate("Setting Built-In RenderPipeline");
                    GraphicsSettings.defaultRenderPipeline = null;
                }
                // Unconditional — a builder project that was previously
                // running URP may have per-level overrides even if
                // defaultRenderPipeline already drifted to null. Clearing
                // every level guarantees the bundle reflects the course's
                // authored pipeline (set later in
                // BuildProcess.CheckForAndSetCustomAssetPipeline) rather than
                // builder-project quality-level defaults.
                PipelineSetter.NullAllQualityLevelPipelines();

                SessionManager.RenderPipelinePass = true;
                EmitPhase(Caffeine.Editor.Build.Protocol.BuildPhases.ConvergeComplete);
                Start();
                return;
            }

            // URP / HDRP
            switch (pipeline)
            {
                case "URP":
                    if (!SessionManager.URPPackageInstalled)
                    {
                        EmitPhase(Caffeine.Editor.Build.Protocol.BuildPhases.ConvergeStart);
                        LogImmediate("Installing Render Pipeline");
                        AddURPPackage(GetCallbackString<PackagePass>(nameof(RenderPipelineCheckFinished)));
                        return;
                    }
                    // Pre-switch defaultRenderPipeline to the package-placeholder
                    // URP asset and flush to disk so PackageImporter.Refresh()'s
                    // out-of-process workers see currentRenderPipeline=URP and
                    // URP's MaterialDescriptionPreprocessor bakes URP/Lit into
                    // FBX-embedded materials. Without this, workers see the
                    // builder project's default null pipeline (the Built-In
                    // branch at line ~160 sets it to null, and the URP branch
                    // previously left it untouched), bake Standard shaders,
                    // and the resulting build ships materials that render pink
                    // on URP devices. BuildProcess.CheckForAndSetCustomAssetPipeline
                    // swaps the placeholder for the course's own URP asset post-
                    // scene-load, so this is purely a worker-visibility fix.
                    AssignPackageURPPreSwitch();
                    break;

                case "HDRP":
                    if (!SessionManager.HDRPPackageInstalled)
                    {
                        EmitPhase(Caffeine.Editor.Build.Protocol.BuildPhases.ConvergeStart);
                        LogImmediate("Installing Render Pipeline");
                        AddHDRPPackage(GetCallbackString<PackagePass>(nameof(RenderPipelineCheckFinished)));
                        return;
                    }
                    break;
            }

            SessionManager.RenderPipelinePass = true;
            EmitPhase(Caffeine.Editor.Build.Protocol.BuildPhases.ConvergeComplete);
            Start();
        }

        // Path duplicated from PipelineSetter.DefaultURPAssetPath
        // (private there) and from ImportBase.CustomImportForNode's
        // pre-switch. If the package is ever renamed, all three sites
        // must update together — worth factoring into an internal const
        // on Caffeine.RenderPipeline if a fourth duplicate appears.
        private const string kPackageURPAssetPath =
            "Packages/com.caffeine/Resources/EditorAssets/URPDefaultResources/URPAsset.asset";

        private static void AssignPackageURPPreSwitch()
        {
            var sw = Stopwatch.StartNew();
            var packageUrp = AssetDatabase.LoadAssetAtPath<RenderPipelineAsset>(kPackageURPAssetPath);
            if (packageUrp != null)
            {
                PipelineSetter.NullAllQualityLevelPipelines();
                GraphicsSettings.defaultRenderPipeline = packageUrp;
                AssetDatabase.SaveAssets();
                sw.Stop();
                Debug.Log(
                    $"[PackagePass] URP pre-switch: {sw.ElapsedMilliseconds} ms. " +
                    $"defaultRenderPipeline={GraphicsSettings.defaultRenderPipeline?.GetType().Name ?? "null"}.");
            }
            else
            {
                sw.Stop();
                Debug.LogWarning(
                    $"[PackagePass] URP pre-switch: package URP placeholder not found at {kPackageURPAssetPath} " +
                    $"({sw.ElapsedMilliseconds} ms). Builder will proceed with current pipeline state — FBX-embedded " +
                    $"materials may bake to Built-In shaders and ship corrupted in the build.");
            }
        }
        
        public static void VisionOSPackageInstalled()
        {
            // Finished VisionOS Package Installation and Resuming Flow
            SessionManager.VisionOSPackageInstalled = true;
            Start();
        }
        
        private static void OnListRequestUpdateForVisionOS()
        {
            if (_listRequest.IsCompleted)
            {
                EditorApplication.update -= OnListRequestUpdateForVisionOS;
                
                if (_listRequest.Status == StatusCode.Success)
                {
                    // Checking For VisionOS Package
                    var visionOSPackage = _listRequest.Result.FirstOrDefault(package => package.name == kVisionOSPackageName);
                    SessionManager.VisionOSPackageInstalled = visionOSPackage is not null;
                    
                    VisionOSCheckFinished();
                }
            }
        }

        private static void OnListRequestUpdateForRenderPipelines()
        {
            if (!_listRequest.IsCompleted) return;

            EditorApplication.update -= OnListRequestUpdateForRenderPipelines;

            if (_listRequest.Status == StatusCode.Success)
            {
                var urpPackageInfo = _listRequest.Result.FirstOrDefault(p => p.name == kURPPackageName);
                var hdrpPackageInfo = _listRequest.Result.FirstOrDefault(p => p.name == kHDRPPackageName);

                SessionManager.URPPackageInstalled = urpPackageInfo is not null;
                SessionManager.HDRPPackageInstalled = hdrpPackageInfo is not null;

                RenderPipelineCheckFinished();
                return;
            }

            // NEW: failure handling
            var errorMsg = _listRequest.Error != null
                ? _listRequest.Error.message
                : _listRequest.Status.ToString();

            LogImmediate($"RenderPipeline Package List Failed: {errorMsg}");
            Debug.LogError($"[Caffeine] RenderPipeline package verification failed: {errorMsg}");

            // Choose one:
            // 1) Fail fast with a clear exit code:
            EditorApplication.Exit((int)ExitCodes.RenderPipelineVerificationFailed);

        }
        
        private static void InvokeStoredMethod(string classFunction)
        {
            // Ensure we wait for assets to finish importing before running
            EditorApplication.update -= WaitForAssetImportAndInvoke;
            EditorApplication.update += WaitForAssetImportAndInvoke;

            void WaitForAssetImportAndInvoke()
            {
                // Prevent execution if Unity is still busy importing or compiling
                if (EditorApplication.isCompiling || AssetDatabase.IsAssetImportWorkerProcess())
                {
                    return;
                }

                // Remove the event so it only runs once when ready
                EditorApplication.update -= WaitForAssetImportAndInvoke;
                ExecuteMethod(classFunction);
            }
        }
        
        private static void ExecuteMethod(string classFunction)
        {
            if (string.IsNullOrEmpty(classFunction) || !classFunction.Contains("."))
            {
                Debug.LogError($"Invalid method format: {classFunction}");
                return;
            }

            var lastDotIndex = classFunction.LastIndexOf('.');
            var className = classFunction.Substring(0, lastDotIndex);
            var methodName = classFunction.Substring(lastDotIndex + 1);

            // Search for the type across all loaded assemblies
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(t => t.FullName == className);

            if (type == null)
            {
                Debug.LogError($"Class not found: {className}");
                return;
            }

            // Find the static method (public or private)
            var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (method == null)
            {
                Debug.LogError($"Method not found: {classFunction}");
                return;
            }
            
            try
            {
                method.Invoke(null, null);
            }
            catch (Exception e)
            {
                Debug.LogError($"Exception invoking method {classFunction}: {e}");
                throw;
            }
            finally
            {
                SessionState.SetString(kPackagePassCallBack, null);
            }
        }
        
        public static void InstallRequiredVisionOSPackage(string callBack)
        {
            if (!string.IsNullOrEmpty(callBack))
            {
                SessionState.SetString(kPackagePassCallBack, callBack);
            }
            
            SessionManager.VisionOSPackageInstalled = false;
            _addRequest = Client.Add("com.unity.xr.visionos");
            
            // Observer Package Installation Attempt If Package Installation Fails Abort Build
            EditorApplication.update += OnAddPackage;
        }

        public static void RemoveURPPackage(string callBack)
        {
            if (!string.IsNullOrEmpty(callBack))
            {
                SessionState.SetString(kPackagePassCallBack, callBack);
            }

            _removeRequest = Client.Remove(kURPPackageName);
            
            // Observe Package Removal
            EditorApplication.update += OnRemovePackage;
        }
        
        public static void AddURPPackage(string callBack)
        {
            if (!string.IsNullOrEmpty(callBack))
            {
                SessionState.SetString(kPackagePassCallBack, callBack);
            }

            SessionManager.URPPackageInstalled = true;
            _addRequest = Client.Add(kURPPackageName);
            
            // Observe Package Removal
            EditorApplication.update += OnAddPackage;
        }
        
        public static void RemoveHDRPPackage(string callBack)
        {
            if (!string.IsNullOrEmpty(callBack))
            {
                SessionState.SetString(kPackagePassCallBack, callBack);
            }

            _removeRequest = Client.Remove(kHDRPPackageName);
            
            // Observe Package Removal
            EditorApplication.update += OnRemovePackage;
        }
        
        public static void AddHDRPPackage(string callBack)
        {
            if (!string.IsNullOrEmpty(callBack))
            {
                SessionState.SetString(kPackagePassCallBack, callBack);
            }

            SessionManager.HDRPPackageInstalled = true;
            _addRequest = Client.Add(kHDRPPackageName);
            
            // Observe Package Removal
            EditorApplication.update += OnAddPackage;
        }
        
        private static void OnAddPackage()
        {
            if (!_addRequest.IsCompleted) return;
            
            EditorApplication.update -= OnAddPackage;
            if (_addRequest.Status != StatusCode.Failure) return;
            
            Debug.Log("Aborting - Failed to add VisionOS Package");
            EditorApplication.Exit(1);
        }

        private static void OnRemovePackage()
        {
            if (!_removeRequest.IsCompleted) return;

            EditorApplication.update -= OnRemovePackage;
            if (_removeRequest.Status != StatusCode.Failure) return;
            
            Debug.Log("Aborting - Failed to remove pipeline package");
            EditorApplication.Exit(1);
        }
        
        private static string GetCallbackString<T>(string methodName)
        {
            return $"{typeof(T).FullName}.{methodName}";
        }
        
        private static void LogImmediate(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            var logMessage = "[BUILDER] " + message;
            Caffeine.Editor.Management.Processes.Logger.Log(logMessage);
            Caffeine.Editor.Build.Protocol.StatusWriter.EmitBuild(message);
        }

        private static void EmitPhase(string phaseName)
        {
            Caffeine.Editor.Build.Protocol.StatusWriter.EmitPhase(phaseName);
        }
    }
}
#endif

