#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System.IO;
    using UnityEngine;
    using UnityEditor;
    
    [InitializeOnLoad]
    public class Paths
    {
        static Paths()
        {
            if (!Application.isBatchMode) return;

            DataPath = Application.dataPath;
            EnsureLogPath();
            EnsureTemporaryPath();
        }
        
        private static readonly int UnityMainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        private const string DataPathKey = "StoredDataPath"; 
        public static bool IsMainThread()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId == UnityMainThreadId;
        }
        
        private static string _dataPath;
        public static string DataPath
        {
            get
            {
                if (IsMainThread())
                {
                    _dataPath = SessionState.GetString(DataPathKey, "");
                }
                return _dataPath;
            }
            set
            {
                if (IsMainThread())
                {
                    SessionState.SetString(DataPathKey, value);
                    _dataPath = value;
                }
            }
        }
        
        private static void EnsureLogPath()
        {
            var projectRootPath = Directory.GetParent(DataPath)?.FullName;
            if (string.IsNullOrEmpty(projectRootPath)) return;

            var logPath = Path.Combine(projectRootPath, "BuildLogs");
            Directory.CreateDirectory(logPath);
        }

        private static void EnsureTemporaryPath()
        {
            var projectRootPath = Directory.GetParent(DataPath)?.FullName;
            if (string.IsNullOrEmpty(projectRootPath)) return;

            var logPath = Path.Combine(projectRootPath, "Temporary");
            Directory.CreateDirectory(logPath);
        }

        public static string GetBuilderRootPath()
        {
            return Directory.GetParent(DataPath)?.FullName;
        }
    }
}
#endif