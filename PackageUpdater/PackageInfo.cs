#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Package
{
    using System;

    [Serializable]
    public class PackageInfo
    {
        public string PackageName;
        public string PackagePath;
        public string PackageID;
    } 
}
#endif