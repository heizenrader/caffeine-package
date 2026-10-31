#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System;
    using System.IO;
    using System.Timers;
    using Build.Session;
    using UnityEditor;
    using UnityEngine;

    [InitializeOnLoad]
    public static class Logger
    {
        private static string _logFilePathCache;
        private static string _activityFilePath;
        private static readonly object _logLock = new object();
        private static readonly object _activityLogLock = new object();
        private static Timer _heartbeatTimer;
        
        static Logger()
        {
            if (!Application.isBatchMode) return;
            
            lock (_logLock)
            {
                _logFilePathCache = SessionManager.LogFilePath;
                //InitializeActivityLog();
            }
        }
        
        private static void InitializeActivityLog()
        {
            if (string.IsNullOrEmpty(_logFilePathCache)) { return; }
            _activityFilePath = Path.ChangeExtension(_logFilePathCache, ".activity");

            try
            {
                if (!File.Exists(_activityFilePath))
                {
                    File.WriteAllText(_activityFilePath, "Activity Log Initialized\n");
                }
            }
            catch
            {
                // Ignored
                return;
            }

            // Start the heartbeat timer
            StartHeartbeat();
        }

        public static void ResetLogPath()
        {
            lock (_logLock)
            {
                _logFilePathCache = SessionManager.LogFilePath;
            }
            
            //InitializeActivityLog();
        }

        public static void Log(string message)
        {
            WriteTextToLog(message);
        }

        private static void WriteTextToLog(string logEvent)
        {
            if (string.IsNullOrEmpty(logEvent) || string.IsNullOrEmpty(_logFilePathCache)) { return;
}
            lock (_logLock)
            {
                try
                {
                    File.AppendAllText(_logFilePathCache, $"{logEvent} {Environment.NewLine}");
                }
                catch
                {
                    // Ignored
                }
            }
        }
        
        private static void StartHeartbeat()
        {
            if (_heartbeatTimer != null)
            {
                _heartbeatTimer.Stop();
                _heartbeatTimer.Dispose();
            }

            _heartbeatTimer = new Timer(30000); // 30 seconds interval
            _heartbeatTimer.Elapsed += AppendHeartbeat;
            _heartbeatTimer.AutoReset = true;
            _heartbeatTimer.Start();
        }
        
        private static void AppendHeartbeat(object sender, ElapsedEventArgs e)
        {
            lock (_activityLogLock)
            {
                try
                {
                    File.AppendAllText(_activityFilePath, $"Heartbeat: {DateTime.UtcNow:O}\n");
                }
                catch 
                {
                    // Ignored
                }
            }
        }
    }
}
#endif