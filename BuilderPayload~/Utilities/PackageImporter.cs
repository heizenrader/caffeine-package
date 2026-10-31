#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Build
{
    using System;
    using System.IO;
    using System.Linq;
    using Caffeine.Editor.Utilities;
    using Management.Processes;
    using Session;
    using UnityEditor;
    using UnityEngine;

    public class PackageImporter
    {
        private static bool _customCodeIncluded = false;
        public static void ImportPackageInStages(string packagePath)
        {
            var tempFolder = Path.Combine(Application.temporaryCachePath, "TempPackage");
            Directory.CreateDirectory(tempFolder);
            PackageExtractor.ExtractPackage(packagePath, tempFolder);

            try
            {
                AssetDatabase.DisallowAutoRefresh();
                AssetDatabase.StartAssetEditing();

                ImportNonScriptAssets(tempFolder);
                ImportAsmdefFiles(tempFolder);
                ImportScriptAssets(tempFolder);
            }
            catch (Exception e)
            {
                Debug.Log("Failed On Import: " + e.Message);
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                AssetDatabase.AllowAutoRefresh();
                AssetDatabase.Refresh();
                Directory.Delete(tempFolder, true);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                EditorApplication.delayCall += delegate
                {
                    if (!SessionManager.ExpectingScriptAssembly && !_customCodeIncluded && !SessionManager.PendingCompilation)
                    {
                        SessionManager.PackageImporting = false;
                        EditorApplication.delayCall += BuildProcess.BuildPackagedScene;
                    }
                };
            }
        }

        private static void ImportNonScriptAssets(string tempFolder)
        {
            var assetPaths = Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories).Where(f => f.EndsWith("pathname")).ToList();
            var nonScriptPaths = (from path in assetPaths let assetPath = File.ReadAllText(path).Trim() where !assetPath.EndsWith(".asmdef") && !assetPath.EndsWith(".cs") select path).ToList();

            foreach (var path in nonScriptPaths)
            {
                ImportAssetAtPathForNode(path);
            }
        }

        private static void ImportScriptAssets(string tempFolder)
        {
            var assetPaths = Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories).Where(f => f.EndsWith("pathname")).ToList();

            var scriptPaths = (from path in assetPaths where File.Exists(path) let assetPath = File.ReadAllText(path).Trim().ToLower() where assetPath.StartsWith("assets") && assetPath.EndsWith(".cs") select path).ToList();
            if (scriptPaths.Count < 1) return;

            _customCodeIncluded = true;
            foreach (var path in scriptPaths)
            {
                ImportAssetAtPathForNode(path);
            }
        }

        public static void ImportAsmdefFiles(string tempFolder)
        {
            var assetPaths = Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories).Where(f => f.EndsWith("pathname")).ToList();
            var scriptPaths = (from path in assetPaths let assetPath = File.ReadAllText(path).Trim() where assetPath.EndsWith(".asmdef") select path).ToList();
            if (scriptPaths is { Count: >= 1 }) { SessionManager.ExpectingScriptAssembly = true; }

            foreach (var path in scriptPaths)
            {
                ImportAssetAtPathForNode(path);
            }
        }

        private static void ImportAssetAtPathForNode(string path)
        {
            var filePathName = new FileInfo(path);
            if (!filePathName.Exists) return;

            var destinationPath = File.ReadAllText(filePathName.FullName).Trim();
            if (destinationPath.StartsWith("Packages/")) return;

            var assetFilePath = filePathName.Directory?.FullName + "/asset";
            var assetFile = new FileInfo(assetFilePath);
            if (!assetFile.Exists) return;

            var assetMetaPath = filePathName.Directory?.FullName + "/asset.meta";
            var assetMetaFile = new FileInfo(assetMetaPath);
            var metaFileDestination = destinationPath + ".meta";

            ImportAssetToPath(assetFile, assetMetaFile, destinationPath, metaFileDestination);
        }

        private static void ImportAssetToPath(FileInfo asset, FileInfo assetMeta, string destinationPath, string metaDestination)
        {
            var invalidPathChars = Path.GetInvalidPathChars();

            destinationPath = invalidPathChars.Aggregate(destinationPath, (current, invalidChar) => current.Replace(invalidChar, '_'));
            metaDestination = invalidPathChars.Aggregate(metaDestination, (current, invalidChar) => current.Replace(invalidChar, '_'));

            var directoryPath = Path.GetDirectoryName(destinationPath);
            if (!string.IsNullOrEmpty(directoryPath)) { Directory.CreateDirectory(directoryPath); }

            asset.CopyTo(destinationPath, true);

            // Preserve the source file's mtime on the destination so
            // Unity's Refresh can skip unchanged files via its cheap
            // mtime filter instead of falling through to content-hashing.
            try { File.SetLastWriteTimeUtc(destinationPath, asset.LastWriteTimeUtc); }
            catch { /* mtime restore is best-effort */ }

            // Only touch the .meta when we have to. Blindly overwriting
            // on every re-import flips MetaFileHash, which invalidates
            // Unity's artifact cache and forces a full re-import of every
            // asset every time. Skip the copy when the existing .meta
            // already has the same GUID as the incoming one.
            if (assetMeta.Exists)
            {
                var incomingGuid = GuidConflictResolver.ReadMetaGuid(assetMeta.FullName);
                var existingGuid = File.Exists(metaDestination) ? GuidConflictResolver.ReadMetaGuid(metaDestination) : null;

                if (existingGuid == null)
                {
                    assetMeta.CopyTo(metaDestination, true);
                    try { File.SetLastWriteTimeUtc(metaDestination, assetMeta.LastWriteTimeUtc); }
                    catch { /* mtime restore is best-effort */ }
                }
                else if (!string.Equals(existingGuid, incomingGuid, StringComparison.Ordinal))
                {
                    assetMeta.CopyTo(metaDestination, true);
                    try { File.SetLastWriteTimeUtc(metaDestination, assetMeta.LastWriteTimeUtc); }
                    catch { /* mtime restore is best-effort */ }
                }
                // else: same GUID — leave existing .meta alone so
                // Unity's artifact cache stays valid.
            }

            // No per-asset ImportAsset call. The surrounding
            // StartAssetEditing / StopAssetEditing + Refresh() handles
            // importing and respects the artifact cache. Calling
            // ImportAsset(ForceSynchronousImport) here bypassed that and
            // ran the importer for every asset on every re-import even
            // when the content was byte-identical.
        }

    }
}
#endif
