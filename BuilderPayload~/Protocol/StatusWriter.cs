#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Build.Protocol
{
    using System;
    using System.IO;
    using System.Threading;
    using Newtonsoft.Json;
    using Session;
    using UnityEditor;
    using UnityEngine;

    // Builder-side emitter for the typed status channel. Mirrors the tagged-log
    // Logger: append-per-write, no held handle, and a failure to write status
    // must never affect the build flow. Emits alongside the legacy
    // [BUILDER]/[UPLOADER] log lines — the parent prefers this channel when
    // present and falls back to log parsing when it is not.
    [InitializeOnLoad]
    public static class StatusWriter
    {
        private static string _statusFilePathCache;
        private static readonly object _statusLock = new object();
        private static long _sequence;

        static StatusWriter()
        {
            if (!Application.isBatchMode) return;

            lock (_statusLock)
            {
                _statusFilePathCache = BuildStatusChannel.PathForBuildLog(SessionManager.LogFilePath);
            }
        }

        // Called next to Logger.ResetLogPath() once the -buildLog CLI arg has
        // been stored in SessionManager, and after every domain reload resume.
        public static void ResetPath()
        {
            if (!Application.isBatchMode) return;

            lock (_statusLock)
            {
                _statusFilePathCache = BuildStatusChannel.PathForBuildLog(SessionManager.LogFilePath);
            }
        }

        public static void EmitBuild(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            Emit(new BuildStatusMessage { Kind = StatusKinds.Build, Message = message });
        }

        public static void EmitUpload(string detail, double percent)
        {
            Emit(new BuildStatusMessage { Kind = StatusKinds.Upload, Message = detail, Progress = percent });
        }

        // Machine-readable phase marker (one of BuildPhases) for the
        // supervisor's admission controller — not user-facing text.
        public static void EmitPhase(string phaseName)
        {
            if (string.IsNullOrEmpty(phaseName)) return;
            Emit(new BuildStatusMessage { Kind = StatusKinds.Phase, Message = phaseName });
        }

        public static void EmitTerminal(bool success, string message, int code)
        {
            Emit(new BuildStatusMessage { Kind = StatusKinds.Terminal, Message = message, Success = success, Code = code });
        }

        // One shader pass/stage is about to compile (from the
        // IPreprocessShaders callback, main thread, inside BuildAssetBundles).
        // Plain file append — safe to call from a build callback.
        public static void EmitShaderPass(string shader, string pass, string stage, int variants)
        {
            Emit(new BuildStatusMessage
            {
                Kind = StatusKinds.Shader,
                Shader = shader ?? string.Empty,
                Pass = pass ?? string.Empty,
                Stage = stage ?? string.Empty,
                Variants = variants < 0 ? 0 : variants,
            });
        }

        // BuildAssetBundles returned (success or not) — closes the shader
        // sub-state on the supervisor regardless of whether any pass was seen.
        public static void EmitShaderComplete()
        {
            Emit(new BuildStatusMessage { Kind = StatusKinds.Shader, Complete = true });
        }

        private static void Emit(BuildStatusMessage message)
        {
            if (string.IsNullOrEmpty(_statusFilePathCache)) return;

            message.Sequence = Interlocked.Increment(ref _sequence);
            message.TimestampUtc = DateTime.UtcNow.ToString("o");

            lock (_statusLock)
            {
                try
                {
                    var line = JsonConvert.SerializeObject(message, Formatting.None);
                    File.AppendAllText(_statusFilePathCache, line + "\n");
                }
                catch
                {
                    // Ignored — status is best-effort; the legacy log channel
                    // and the process exit code remain authoritative fallbacks.
                }
            }
        }
    }
}
#endif
