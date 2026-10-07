#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System;
    using System.IO;
    using Build.Process;
    using Build.Protocol;
    using Build.Session;
    using UnityEditor;
    using UnityEngine;

    public static class ImportProcess
    {
        public static void StartBuildForScenePackagePath()
        {
            Debug.Log("C001 - StartBuildForScenePackagePath - ExecuteMethod Entry Point");
            if (!Application.isBatchMode) return;
            
            Application.logMessageReceived -= HandleLog;
            Application.logMessageReceived += HandleLog;
            
            // 1 - Start Session (Tracks Session Data)
            StartSession();
            
            // 2 - Begin Package Pass To Confirm Required Packages  // 3 Is Resumed From Within PackagePass
            Management.PackagePass.Begin();
            Debug.Log("C001.1 - StartBuildForScenePackagePath - Finish Point");
        }
        
        private static void StartSession()
        {
            Debug.Log("C002 - StartSession - Tracking This Builders Session");

            try
            {
                var args = System.Environment.GetCommandLineArgs();
                var buildLogPath = "";

                for (var i = 0; i < args.Length; i++)
                {
                    var arg = args[i];
                    
                    if (arg.StartsWith("-scenePath"))
                    {
                        if (i + 1 < args.Length)
                        {
                            var scenePath = args[i + 1];
                            if (!string.IsNullOrEmpty(scenePath))
                            {
                                SessionManager.PackageScenePath = scenePath;
                            }
                            else
                            {
                                var aboutMessage = $"Aborting - Unable to locate course scene file.";
                                Debug.Log(aboutMessage);
                                EditorApplication.Exit((int)ExitCodes.SceneNotFound);
                            }
                        }
                    }

                    if (arg.StartsWith("-nodePath"))
                    {
                        if (i + 1 < args.Length)
                        {
                            var nodePath = args[i + 1];
                            if (!string.IsNullOrEmpty(nodePath))
                            {
                                var nodeID = Path.GetFileName(nodePath);
                                var updatedNodePath = Path.Combine(nodePath, $"{nodeID}.node_data~");
                                SessionManager.NodePath = updatedNodePath;
                            }
                        }
                    }

                    if (arg.StartsWith("-jwtPath"))
                    {
                        if (i + 1 < args.Length)
                        {
                            var jwtPath = args[i + 1];
                            if (!string.IsNullOrEmpty(jwtPath))
                            {
                                SessionManager.JWTPath = jwtPath;
                            }
                        }
                    }
                    
                    if (arg.StartsWith("-buildLog"))
                    {
                        if (i + 1 < args.Length)
                        {
                            buildLogPath = args[i + 1];
                            SessionManager.LogFilePath = buildLogPath;
                            Logger.ResetLogPath();
                            StatusWriter.ResetPath();
                        }
                    }

                    if (arg.StartsWith("-bypassUpload"))
                    {
                        SessionManager.BypassUpload = true;
                    }
                    
                    if (arg.StartsWith("-assemblyUploadOnly"))
                    {
                        SessionManager.UploadAssemblyOnly = true;
                    }

                    if (arg.StartsWith("-multiProcessBuild"))
                    {
                        SessionManager.MultiProcessBuild = true;
                    }

                    if (arg.StartsWith("-parallelImport"))
                    {
                        SessionManager.ParallelImport = true;
                    }

                    if (arg == "-renderPipeline")
                    {
                        string value = null;
                        if (i + 1 < args.Length)
                        {
                            value = args[i + 1];
                        }

                        // If missing or looks like another flag, treat as STANDARD
                        if (string.IsNullOrEmpty(value) || value.StartsWith("-"))
                        {
                            SessionManager.RenderPipeline = "STANDARD";
                        }
                        else
                        {
                            SessionManager.RenderPipeline = value.ToUpperInvariant() switch
                            {
                                "URP" or "HDRP" or "STANDARD" => value.ToUpperInvariant(),
                                _ => "STANDARD"
                            };
                        }
                    }
                }
                
                if (EditorUserBuildSettings.activeBuildTarget == (BuildTarget)47)
                {
                    SessionManager.IsVisionOS = true;
                }
                
                if (SessionManager.MultiProcessBuild)
                {
                    try
                    {
                        EditorBuildSettings.UseParallelAssetBundleBuilding = true;
                        Debug.Log("[BUILDER] Multi-Process AssetBundle Building Enabled");
                    }
                    catch (Exception e)
                    {
                        Debug.Log("[BUILDER] Failed to enable multi-process build: " + e.Message);
                    }
                }

                if (SessionManager.ParallelImport)
                {
                    try
                    {
                        EditorSettings.refreshImportMode = AssetDatabase.RefreshImportMode.OutOfProcessPerQueue;
                        Debug.Log("[BUILDER] Parallel Import Enabled");
                    }
                    catch (Exception e)
                    {
                        Debug.Log("[BUILDER] Failed to set parallel import: " + e.Message);
                    }
                }

                StatusWriter.EmitPhase(BuildPhases.SessionStart);
                LogImmediate("Setting Session Variables");
            }
            catch (Exception e)
            {
                Debug.Log("Import Failure: " + e.Message);
                LogImmediate("Importing Scene Package Failed");
                EditorApplication.Exit((int)ExitCodes.ExceptionWithPackageImportProcess);
            }
            
            Debug.Log("C002.1 - StartSession - End Point For Session Tracking");
        }

        private static void LogImmediate(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            var logMessage = "[BUILDER] " + message;
            Logger.Log(logMessage);
            StatusWriter.EmitBuild(message);
        }
        
        
        private static void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (type == LogType.Exception && !string.IsNullOrEmpty(logString))
            {
                Debug.Log("Exiting due to error in batch mode: " + logString);
                // TO:DO Need To Setup An Activity Timeout and EditorApplication.Exit() if activity isn't sceen.
            }
        }
    }
}
#endif