#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Build
{
    using Management.Processes;
    using Session;
    using UnityEditor;
    using UnityEditor.Compilation;
    using UnityEngine;
    
    [InitializeOnLoad]
    public static class BuildSessionManager
    { 
        static BuildSessionManager()
        {
            if (!Application.isBatchMode) return;

            AssemblyReloadEvents.beforeAssemblyReload -= BeforeAssemblyReload;
            AssemblyReloadEvents.beforeAssemblyReload += BeforeAssemblyReload;
            AssemblyReloadEvents.afterAssemblyReload -= AfterAssemblyReload;
            AssemblyReloadEvents.afterAssemblyReload += AfterAssemblyReload;
            
            CompilationPipeline.compilationStarted -= OnCompilationStarted;
            CompilationPipeline.compilationStarted += OnCompilationStarted;
            CompilationPipeline.compilationFinished -= OnCompilationFinished;
            CompilationPipeline.compilationFinished += OnCompilationFinished;
        }
        
        public static void AfterAssemblyReload()
        {
            SessionManager.PendingDomainReload = false;
            
            if (SessionManager.PackageImporting && !SessionManager.PendingCompilation)
            {
                SessionManager.PackageImporting = false;
                EditorApplication.delayCall += BuildProcess.BuildPackagedScene;
            }
        }

        public static void BeforeAssemblyReload()
        {
            SessionManager.PendingDomainReload = true;
        }
        
        private static void OnCompilationStarted(object context)
        {
            SessionManager.PendingCompilation = true;
        }

        private static void OnCompilationFinished(object context)
        {
            SessionManager.PendingCompilation = false;
        }
    }
}
#endif
