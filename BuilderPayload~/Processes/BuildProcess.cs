#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Build.Process;
    using Build.Protocol;
    using Build.Session;
    using Caffeine.Flow.Graphs.SceneGraphs;
    using Caffeine.Runtime.Core.Models;
    using RenderPipeline;
    using Runtime.Course;
    using Scriptables.Cache.Graphics;
    using UnityEditor;
    using UnityEditor.Build.Player;
    using UnityEditor.SceneManagement;
    using UnityEngine;
    using UnityEngine.Rendering;
    using Object = UnityEngine.Object;


    static class BuildProcess
    {
        private static BuildProfile _buildProfile;
        
        public static async void BuildPackagedScene()
        {
            try
            {
                StatusWriter.EmitPhase(BuildPhases.ImportComplete);
                LogImmediate($"Package Was Imported");
                SessionManager.AttemptingBuild = true;
                
                var scenePackageName = SessionManager.PackageScenePath;
                var sceneName = "";
                
                if (!string.IsNullOrEmpty(scenePackageName))
                {
                    sceneName = Path.GetFileNameWithoutExtension(scenePackageName);
                }
                
                if (string.IsNullOrEmpty(sceneName))
                {
                    LogImmediate("Unable To Locate Scene - Aborting");
                    EditorApplication.Exit((int)ExitCodes.SceneNotFound);
                    return;
                }
                
                // Load And Unpack Prefabs For Performance Also Loading Scene For Course Detection For RenderPipeline
                var scenePaths = AssetDatabase.FindAssets("t:Scene").Select(AssetDatabase.GUIDToAssetPath);
                var scenePathToLoad = scenePaths.FirstOrDefault(scenePath => scenePath.Contains(sceneName));
                
                if (string.IsNullOrEmpty(scenePathToLoad) || !File.Exists(scenePathToLoad))
                {
                    LogImmediate($"Build Aborting ({(int)ExitCodes.SceneNotFound})");
                    EditorApplication.Exit((int)ExitCodes.SceneNotFound);
                    return;
                }
                
                var sceneLoadedAndUnpacked = UnpackPrefabsInScene(scenePathToLoad);
                if (!sceneLoadedAndUnpacked)
                {
                    LogImmediate($"Build Failed ({(int)ExitCodes.SceneInvalidOrFailedToLoad})");
                    EditorApplication.Exit((int)ExitCodes.SceneInvalidOrFailedToLoad);
                    return;
                }
                
                CheckForAndSetCustomAssetPipeline();
                
                await Build(sceneName);
            }
            catch (Exception e)
            {
                Debug.LogError("Inside Try For BuildPackagedScene");
                Debug.LogError("💥 EXCEPTION OCCURRED 💥");
                Debug.LogError("Message: " + e.Message);
                Debug.LogError("StackTrace: " + e.StackTrace);
                Debug.LogError("Source: " + e.Source);
                Debug.LogError("TargetSite: " + e.TargetSite);
                Debug.LogError("Exception Type: " + e.GetType().FullName);

                if (e.InnerException != null)
                {
                    Debug.LogError("Inner Exception: " + e.InnerException.Message);
                    Debug.LogError("Inner StackTrace: " + e.InnerException.StackTrace);
                }
                
                LogImmediate("Exception After Package Import - Check Unity Log");
                EditorApplication.Exit((int)ExitCodes.ExceptionWithProcessingBuildingPackagedScene);
            }
        }

        private static void CheckForAndSetCustomAssetPipeline()
        {
            var loadedCourse = Object.FindObjectOfType<Course>();
            if (loadedCourse == null) { return; }

            LogImmediate("Setting RenderPipeline");

            // Clear per-level QualitySettings overrides before assigning the
            // course's authored pipeline to GraphicsSettings. Any AssetBundle
            // written downstream of this call needs the per-level overrides
            // out of the way so the bundle reflects loadedCourse.RenderPipeLine
            // rather than whatever the builder project's QualitySettings.asset
            // ships with.
            PipelineSetter.NullAllQualityLevelPipelines();

            if (loadedCourse.RenderPipeLine != null)
            {
                GraphicsSettings.defaultRenderPipeline = loadedCourse.RenderPipeLine;
            }
            else if (GraphicsSettings.currentRenderPipeline != null)
            {
                GraphicsSettings.defaultRenderPipeline = null;
            }
        }
        
        private static async Task Build(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                LogImmediate("Build Aborting - Scene Not Found");
                EditorApplication.Exit((int)ExitCodes.SceneNotFound);
                return;
            }
            
            try
            {
                var currentPlatform = EditorUserBuildSettings.activeBuildTarget;
                var nodePath = SessionManager.NodePath;
                Node node = null;
                
                if (!string.IsNullOrEmpty(nodePath))
                {
                    node = Node.NodeAtPath(nodePath);
                }
                
                var contentTag = currentPlatform switch
                {
                    BuildTarget.Android => "ANDROID_CONTENT",
                    BuildTarget.iOS => "IOS_CONTENT",
                    BuildTarget.StandaloneWindows64 => "STANDALONE_CONTENT",
                    BuildTarget.StandaloneOSX => "STANDALONE_MAC_CONTENT",
                    (BuildTarget)47 => "VISION_OS_CONTENT",
                    BuildTarget.WebGL => "WEB_CONTENT",
                    _ => null
                };
                
                var assemblyTag = currentPlatform switch
                {
                    BuildTarget.Android => "ANDROID_ASSEMBLY",
                    BuildTarget.iOS => "IOS_ASSEMBLY",
                    BuildTarget.StandaloneWindows64 => "STANDALONE_ASSEMBLY",
                    BuildTarget.StandaloneOSX => "STANDALONE_MAC_ASSEMBLY",
                    (BuildTarget)47 => "VISION_OS_ASSEMBLY",
                    BuildTarget.WebGL => "WEB_ASSEMBLY",
                    _ => null
                };
                
                if (SessionManager.UploadAssemblyOnly)
                {
                    if (node == null)
                    {
                        LogImmediate("Failed To Upload Assembly - Invalid Node");
                        EditorApplication.Exit((int)ExitCodes.NodeMissing);
                        return;
                    }
                    
                    if (assemblyTag == null)
                    {
                        LogImmediate("Failed To Upload Assembly - Unknown Build Platform");
                        EditorApplication.Exit((int)ExitCodes.AssemblyTagInvalid);
                        return;
                    }

                    var assemblyUploaded = await BuildUpload.UploadAssemblyAssetForNode(assemblyTag, node);
                 
                    LogImmediate(!assemblyUploaded ? "Failed To Upload Assembly" : "Assembly Upload Succeeded");
                    var statusCode = !assemblyUploaded ? (int)ExitCodes.AssemblyFailedToUpload : 0;
                    StatusWriter.EmitTerminal(assemblyUploaded, !assemblyUploaded ? "Failed To Upload Assembly" : "Assembly Upload Succeeded", statusCode);
                    EditorApplication.Exit(statusCode);
                }
                
                StatusWriter.EmitPhase(BuildPhases.BundleStart);
                LogImmediate($"Creating Streaming Asset Bundle");
                var scenePaths = AssetDatabase.FindAssets("t:Scene").Select(AssetDatabase.GUIDToAssetPath);
                var scenePathToLoad = scenePaths.FirstOrDefault(scenePath => scenePath.Contains(sceneName));

                if (string.IsNullOrEmpty(scenePathToLoad) || !File.Exists(scenePathToLoad))
                {
                    LogImmediate($"Build Aborting ({(int)ExitCodes.SceneNotFound})");
                    EditorApplication.Exit((int)ExitCodes.SceneNotFound);
                    return;
                }
                
                _buildProfile = BuildProfile.BuildProfileForResourcePath(scenePathToLoad);

                var bundlePath = Path.Combine(_buildProfile.outputPath, _buildProfile.bundleName);
                if (File.Exists(bundlePath)) File.Delete(bundlePath);
                
                // Shader compilation runs inside BuildAssetBundles and reports
                // per pass via ShaderCompileReporter (IPreprocessShaders). The
                // closing line goes out in `finally` so the supervisor's shader
                // sub-state ends even when the bundle build fails or throws.
                AssetBundleManifest manifest;
                try
                {
                    manifest = BuildPipeline.BuildAssetBundles(_buildProfile.outputPath, _buildProfile.Map, BuildAssetBundleOptions.ChunkBasedCompression, currentPlatform);
                }
                finally
                {
                    StatusWriter.EmitShaderComplete();
                }

                if (manifest == null)
                {
                    LogImmediate($"Build Failed ({(int)ExitCodes.FailedAssetBundleCreation})");
                    EditorApplication.Exit((int)ExitCodes.FailedAssetBundleCreation);
                    return;
                }
                
                var bypassUpload = SessionManager.BypassUpload;
                if (bypassUpload)
                {
                    if (File.Exists(Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Library", "ScriptAssemblies", "CaffeinePlus.dll"))))
                    {
                        // Generate Assembly
                        CollectAndCompileScripts(currentPlatform);
                    }
                    
                    LogImmediate("Build Succeeded");
                    StatusWriter.EmitTerminal(true, "Build Succeeded", 0);
                    EditorApplication.Exit(0);
                    return;
                }

                if (node == null)
                {
                    LogImmediate("Build Succeeded - Failed To Upload");
                    StatusWriter.EmitTerminal(true, "Build Succeeded - Failed To Upload", (int)ExitCodes.AssetBundleFailedToUpload);
                    EditorApplication.Exit((int)ExitCodes.AssetBundleFailedToUpload);
                    return;
                }

                if (string.IsNullOrEmpty(contentTag))
                {
                    LogImmediate($"Build Aborting ({(int)ExitCodes.AssetBundleTagInvalid})");
                    EditorApplication.Exit((int)ExitCodes.AssetBundleTagInvalid);
                    return;
                }
                
                var assetBundleUploaded = await BuildUpload.UploadBundleAssetForNode(bundlePath, contentTag, node);
                
                if (!File.Exists(Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Library", "ScriptAssemblies", "CaffeinePlus.dll"))))
                {
                    var statusCode = assetBundleUploaded ? 0 : (int)ExitCodes.AssetBundleFailedToUpload;
                    LogImmediate(assetBundleUploaded ? "Publish Succeeded" : $"Publish Failed ({statusCode})");
                    StatusWriter.EmitTerminal(assetBundleUploaded, assetBundleUploaded ? "Publish Succeeded" : $"Publish Failed ({statusCode})", statusCode);
                    EditorApplication.Exit(statusCode);
                    return;
                }
                
                // Generate Assembly
                CollectAndCompileScripts(currentPlatform);
                
                // Check For Created Assembly
                if (!File.Exists(Path.Combine(Application.dataPath, "..", "Temporary", "CaffeinePlus.dll")))
                {
                    var statusCode = (int)ExitCodes.AssemblyFailedToUpload;
                    LogImmediate($"Assembly Failed To Upload ({statusCode})");
                    EditorApplication.Exit(statusCode);
                    return;
                }
                
                if (assemblyTag == null)
                {
                    LogImmediate($"Assembly Aborting ({(int)ExitCodes.AssemblyTagInvalid})");
                    EditorApplication.Exit((int)ExitCodes.AssemblyTagInvalid);
                    return;
                }

                var aUploaded = await BuildUpload.UploadAssemblyAssetForNode(assemblyTag, node);
                
                LogImmediate(assetBundleUploaded && aUploaded ? "Publish Succeeded" : $"Publish Succeeded With Error ({(int)ExitCodes.BundleOrAssemblyFailedUpload})");
                var fallThroughStatusCode = !assetBundleUploaded || !aUploaded ? (int)ExitCodes.BundleOrAssemblyFailedUpload : 0;
                // success:true even on the with-error path — the builder's own rails
                // finished, which is what arms the parent's shutdown watchdog; the
                // publish verdict still comes from the exit code.
                StatusWriter.EmitTerminal(true, assetBundleUploaded && aUploaded ? "Publish Succeeded" : $"Publish Succeeded With Error ({(int)ExitCodes.BundleOrAssemblyFailedUpload})", fallThroughStatusCode);
                EditorApplication.Exit(fallThroughStatusCode);
            }
            catch (Exception e)
            {
                Debug.LogError("Inside Try For Build");
                Debug.LogError("💥 EXCEPTION OCCURRED 💥");
                Debug.LogError("Message: " + e.Message);
                Debug.LogError("StackTrace: " + e.StackTrace);
                Debug.LogError("Source: " + e.Source);
                Debug.LogError("TargetSite: " + e.TargetSite);
                Debug.LogError("Exception Type: " + e.GetType().FullName);

                if (e.InnerException != null)
                {
                    Debug.LogError("Inner Exception: " + e.InnerException.Message);
                    Debug.LogError("Inner StackTrace: " + e.InnerException.StackTrace);
                }
                
                LogImmediate($"Build Aborting With Exception - Check Unity Log");
                EditorApplication.Exit((int)ExitCodes.ExceptionWithBuildUploadProcess);
            }
        }
        
        private static void CollectAndCompileScripts(BuildTarget buildTarget)
        {
            var buildTargetGroup = BuildTargetGroup.Unknown;
           
            switch (buildTarget)
            {
                case BuildTarget.iOS:
                    buildTargetGroup = BuildTargetGroup.iOS;
                    break;
                case BuildTarget.Android:
                    buildTargetGroup = BuildTargetGroup.Android;
                    break;
                case BuildTarget.StandaloneWindows64:
                    buildTargetGroup = BuildTargetGroup.Standalone;
                    break;
                case BuildTarget.StandaloneOSX:
                    buildTargetGroup = BuildTargetGroup.Standalone;
                    break;
                case BuildTarget.VisionOS:
                    buildTargetGroup = BuildTargetGroup.VisionOS;
                    break;
                case BuildTarget.WebGL:
                    buildTargetGroup = BuildTargetGroup.WebGL;
                    break;
            }

            if (buildTargetGroup == BuildTargetGroup.Unknown) return;
            
            var scriptCompilationSettings = new ScriptCompilationSettings
            {
                target = buildTarget,
                group = buildTargetGroup
            };

            var outputPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Temporary"));
            PlayerBuildInterface.CompilePlayerScripts(scriptCompilationSettings, outputPath);
        }
        
        private static bool UnpackPrefabsInScene(string scenePath)
        {
            if (File.Exists(scenePath))
            {
                var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
                if (!scene.IsValid() || !scene.isLoaded) return false;
                
                foreach (GameObject rootObject in scene.GetRootGameObjects())
                {
                    UnpackPrefabRecursive(rootObject);
                }
                
                EditorSceneManager.SaveScene(scene);

                return true;
            }

            return false;
        }
    
        private static void UnpackPrefabRecursive(GameObject obj)
        {
            if (PrefabUtility.IsPartOfAnyPrefab(obj))
            {
                // Check To See If Any Part Of The Prefab Has A Scene Graph
                if (HasScriptInHierarchy<EdXR_SceneGraph>(obj))
                {
                    //This is in OutermostRoot because it breaks the fix references process for prefabs that contain nested prefabs
                
                    if (PrefabUtility.IsPartOfVariantPrefab(obj))
                    {
                        var root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);
                        if (root != null)
                        {
                            PrefabUtility.UnpackPrefabInstance(root, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);

                            if (PrefabUtility.IsPartOfAnyPrefab(root))
                            {
                                PrefabUtility.UnpackPrefabInstance(root, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
                            }
                        }
                    }
                    else
                    {
                        // Double Check To Ensure Is Root Object
                        var root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);
                        if (root != null)
                        {
                            PrefabUtility.UnpackPrefabInstance(root, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
                        }
                    }
                }
            }

            foreach (Transform child in obj.transform)
            {
                UnpackPrefabRecursive(child.gameObject);
            }
        }
        
        private static bool HasScriptInHierarchy<T>(GameObject obj) where T : Component
        {
            return obj.GetComponent<T>() != null || obj.transform.Cast<Transform>().Any(child => HasScriptInHierarchy<T>(child.gameObject));
        }
        
        private static void LogImmediate(string message)
        {
            var logMessage = "[BUILDER] " + message;
            Logger.Log(logMessage);
            StatusWriter.EmitBuild(message);
        }

        private static void LogUploadProgress(string message)
        {
            var logMessage = "[UPLOADER] " + message;
            Logger.Log(logMessage);
        }
    }
}
#endif
