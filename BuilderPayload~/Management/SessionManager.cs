#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Build.Session
{
    using UnityEditor;
    using UnityEngine;
    
    public static class SessionKeys
    {
        public static readonly string PendingCompilation = "IsCompilationPending";
        public static readonly string Pending_Domain_Reload = "PendingDomainReload";
        public static readonly string Package_Importing = "ImportingPackage";
        public static readonly string Package_Imported = "PackageImported";
        public static readonly string Package_Scene_Path = "PackageScenePath";
        public static readonly string Node_Path = "NodePath";
        public static readonly string JWT_Path = "JWTPath";
        public static readonly string Bypass_Upload = "BypassUpload";
        public static readonly string Attempting_Build = "AttemptingBuild";
        public static readonly string Assembly_Upload_Only = "UploadAssemblyOnly";
        public static readonly string Log_File_Path = "LogFilePath";
        public static readonly string Expecting_Script_Assembly = "ExpectingScriptAssembly";
        public static readonly string Is_VisionOS = "VisionOSBuild";
        public static readonly string VisionOS_Package_Installed = "IsVisionOSPackageInstalled";
        public static readonly string Render_Pipeline = "RequestedRenderPipeline";
        public static readonly string Package_Pass = "RequiredPackagesAreInstalled";
        public static readonly string Pipeline_Verified = "PassedPieplineVerification";
        public static readonly string URPPackage_Installed = "IsURPInstalled";
        public static readonly string HDRPPackage_Installed = "IsHDRPInstalled";
        public static readonly string Multi_Process_Build = "MultiProcessBuild";
        public static readonly string Parallel_Import = "ParallelImport";
    }
    
    [InitializeOnLoad]
    public static class SessionManager
    {
        static SessionManager()
        {
            if (!Application.isBatchMode) return;
            
            _packageImporting = SessionState.GetBool(SessionKeys.Package_Importing, false);
            _packageImported = SessionState.GetBool(SessionKeys.Package_Imported, false);
            _bypassUpload = SessionState.GetBool(SessionKeys.Bypass_Upload, false);
            _uploadAssemblyOnly = SessionState.GetBool(SessionKeys.Assembly_Upload_Only, false);
            _expectingScriptAssembly = SessionState.GetBool(SessionKeys.Expecting_Script_Assembly, false);
            _pendingDomainReload = SessionState.GetBool(SessionKeys.Pending_Domain_Reload, false);
            _packageScenePath = SessionState.GetString(SessionKeys.Package_Importing, "");
            _nodePath = SessionState.GetString(SessionKeys.Node_Path, "");
            _jwtPath = SessionState.GetString(SessionKeys.JWT_Path, "");
            _logFilePath = SessionState.GetString(SessionKeys.Log_File_Path, "");
            _isVisionOS = SessionState.GetBool(SessionKeys.Is_VisionOS, false);
            _visionOSPackageInstalled = SessionState.GetBool(SessionKeys.VisionOS_Package_Installed, false);
            _pendingCompilation = SessionState.GetBool(SessionKeys.PendingCompilation, false);
            _renderPipeline = SessionState.GetString(SessionKeys.Render_Pipeline, "");
            _renderPipelinePass = SessionState.GetBool(SessionKeys.Pipeline_Verified, false);
            _urpPackageInstalled = SessionState.GetBool(SessionKeys.URPPackage_Installed, false);
            _hdrpPackageInstalled = SessionState.GetBool(SessionKeys.HDRPPackage_Installed, false);
            _multiProcessBuild = SessionState.GetBool(SessionKeys.Multi_Process_Build, false);
            _parallelImport = SessionState.GetBool(SessionKeys.Parallel_Import, false);
        }

        
        private static readonly int UnityMainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

        private static bool _packageImporting;

        public static bool PackageImporting
        {
            get
            {
                if (IsMainThread()) { _packageImporting = SessionState.GetBool(SessionKeys.Package_Importing, false); }
                return _packageImporting;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Package_Importing, value); }
                _packageImporting = value;
            }
        }
        
        private static bool _urpPackageInstalled;

        public static bool URPPackageInstalled
        {
            get
            {
                if (IsMainThread()) { _urpPackageInstalled = SessionState.GetBool(SessionKeys.URPPackage_Installed, false); }
                return _urpPackageInstalled;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.URPPackage_Installed, value); }
                _urpPackageInstalled = value;
            }
        }
        
        private static bool _hdrpPackageInstalled;

        public static bool HDRPPackageInstalled
        {
            get
            {
                if (IsMainThread()) { _hdrpPackageInstalled = SessionState.GetBool(SessionKeys.HDRPPackage_Installed, false); }
                return _hdrpPackageInstalled;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.HDRPPackage_Installed, value); }
                _hdrpPackageInstalled = value;
            }
        }
        
        private static bool _packagePass;

        public static bool PackagePass
        {
            get
            {
                if (IsMainThread()) { _packagePass = SessionState.GetBool(SessionKeys.Package_Pass, false); }
                return _packagePass;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Package_Pass, value); }
                _packagePass = value;
            }
        }
        
        private static bool _renderPipelinePass;

        public static bool RenderPipelinePass
        {
            get
            {
                if (IsMainThread()) { _renderPipelinePass = SessionState.GetBool(SessionKeys.Pipeline_Verified, false); }
                return _renderPipelinePass;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Pipeline_Verified, value); }
                _renderPipelinePass = value;
            }
        }
        
        private static bool _packageImported;

        public static bool PackageImported
        {
            get
            {
                if (IsMainThread()) { _packageImported = SessionState.GetBool(SessionKeys.Package_Imported, false); }
                return _packageImported;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Package_Imported, value); }
                _packageImported = value;
            }
        }
        
        private static bool _pendingDomainReload;

        public static bool PendingDomainReload
        {
            get
            {
                if (IsMainThread()) { _pendingDomainReload = SessionState.GetBool(SessionKeys.Pending_Domain_Reload, false); }
                return _pendingDomainReload;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Pending_Domain_Reload, value); }
                _pendingDomainReload = value;
            }
        }
        
        private static bool _pendingCompilation;

        public static bool PendingCompilation
        {
            get
            {
                if (IsMainThread()) { _pendingCompilation = SessionState.GetBool(SessionKeys.PendingCompilation, false); }
                return _pendingCompilation;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.PendingCompilation, value); }
                _pendingCompilation = value;
            }
        }

        private static string _packageScenePath;

        public static string PackageScenePath
        {
            get
            {
                if (IsMainThread()){ _packageScenePath = SessionState.GetString(SessionKeys.Package_Scene_Path, ""); }
                return _packageScenePath;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetString(SessionKeys.Package_Scene_Path, value); }
                _packageScenePath = value;
            }
        }
        
        private static bool _visionOSPackageInstalled;

        public static bool VisionOSPackageInstalled
        {
            get
            {
                if (IsMainThread()) { _visionOSPackageInstalled = SessionState.GetBool(SessionKeys.VisionOS_Package_Installed, false); }
                return _visionOSPackageInstalled;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.VisionOS_Package_Installed, value); }
                _visionOSPackageInstalled = value;
            }
        }
        
        private static bool _isVisionOS;

        public static bool IsVisionOS
        {
            get
            {
                if (IsMainThread()) { _isVisionOS = SessionState.GetBool(SessionKeys.Is_VisionOS, false); }
                return _isVisionOS;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Is_VisionOS, value); }
                _isVisionOS = value;
            }
        }
        
        private static string _nodePath;

        public static string NodePath
        {
            get
            {
                if (IsMainThread()) { _nodePath = SessionState.GetString(SessionKeys.Node_Path, ""); }
                return _nodePath;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetString(SessionKeys.Node_Path, value); }
                _nodePath = value;
            }
        }

        private static string _jwtPath;

        public static string JWTPath
        {
            get
            {
                if (IsMainThread()) { _jwtPath = SessionState.GetString(SessionKeys.JWT_Path, ""); }
                return _jwtPath;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetString(SessionKeys.JWT_Path, value); }
                _jwtPath = value;
            }
        }

        private static bool _bypassUpload;

        public static bool BypassUpload
        {
            get
            {
                if (IsMainThread()) { _bypassUpload = SessionState.GetBool(SessionKeys.Bypass_Upload, false); }
                return _bypassUpload;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Bypass_Upload, value); }
                _bypassUpload = value;
            }
        }
        
        private static bool _expectingScriptAssembly;

        public static bool ExpectingScriptAssembly
        {
            get
            {
                if (IsMainThread()) { _expectingScriptAssembly = SessionState.GetBool(SessionKeys.Expecting_Script_Assembly, false); }
                return _expectingScriptAssembly;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Expecting_Script_Assembly, value); }
                _expectingScriptAssembly = value;
            }
        }

        private static bool _uploadAssemblyOnly;

        public static bool UploadAssemblyOnly
        {
            get
            {
                if (IsMainThread()) { _uploadAssemblyOnly = SessionState.GetBool(SessionKeys.Assembly_Upload_Only, false); }
                return _uploadAssemblyOnly;
            }
            set
            { 
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Assembly_Upload_Only, value); }
                _uploadAssemblyOnly = value;
            }
        }

        private static bool _attemptingBuild;

        public static bool AttemptingBuild
        {
            get
            {
                if (IsMainThread()) { _attemptingBuild = SessionState.GetBool(SessionKeys.Attempting_Build, false); }
                return _attemptingBuild;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Attempting_Build, value); }
                _attemptingBuild = value;
            }
        }

        private static string _logFilePath;
        public static string LogFilePath
        {
            get
            {
                if (IsMainThread()) { _logFilePath = SessionState.GetString(SessionKeys.Log_File_Path, ""); }
                return _logFilePath;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetString(SessionKeys.Log_File_Path, value); }
                _logFilePath = value;
            }
        }
        
        private static string _renderPipeline;

        public static string RenderPipeline
        {
            get
            {
                if (IsMainThread()) { _renderPipeline = SessionState.GetString(SessionKeys.Render_Pipeline, ""); }
                return _renderPipeline;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetString(SessionKeys.Render_Pipeline, value); }
                _renderPipeline = value;
            }
        }
        
        private static bool _multiProcessBuild;

        public static bool MultiProcessBuild
        {
            get
            {
                if (IsMainThread()) { _multiProcessBuild = SessionState.GetBool(SessionKeys.Multi_Process_Build, false); }
                return _multiProcessBuild;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Multi_Process_Build, value); }
                _multiProcessBuild = value;
            }
        }

        private static bool _parallelImport;

        public static bool ParallelImport
        {
            get
            {
                if (IsMainThread()) { _parallelImport = SessionState.GetBool(SessionKeys.Parallel_Import, false); }
                return _parallelImport;
            }
            set
            {
                if (IsMainThread()) { SessionState.SetBool(SessionKeys.Parallel_Import, value); }
                _parallelImport = value;
            }
        }

        public static bool IsMainThread()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId == UnityMainThreadId;
        }
    }
}
#endif