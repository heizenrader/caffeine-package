#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System.IO;
    using UnityEditor;
    
    public class BuildProfile
    {
        public string sceneName;
        public string outputPath;
        public string bundleName;
        public string scenePath;

        public AssetBundleBuild[] Map
        {
            get
            {
                var newBuildMap = new AssetBundleBuild[1];
                newBuildMap[0].assetBundleName = $"{sceneName}_{EditorUserBuildSettings.activeBuildTarget.ToString().ToLower()}.bundle";

                var assetPaths = new string[1];
                assetPaths[0] = scenePath;
                newBuildMap[0].assetNames = assetPaths;

                return newBuildMap;
            }
        }

        public static BuildProfile BuildProfileForResourcePath(string scenePath)
        {
            Directory.CreateDirectory("Assets/Builds");

            var sceneName = Path.GetFileNameWithoutExtension(scenePath);
            var returnBuildProfile = new BuildProfile();

            var bundleName = $"{sceneName}_{EditorUserBuildSettings.activeBuildTarget.ToString().ToLower()}.bundle";

            returnBuildProfile.scenePath = scenePath;
            returnBuildProfile.bundleName = bundleName;
            returnBuildProfile.sceneName = sceneName;
            returnBuildProfile.outputPath = $"Assets/Builds";

            return returnBuildProfile;
        }
    }
}
#endif