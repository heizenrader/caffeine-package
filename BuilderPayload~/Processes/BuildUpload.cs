#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Caffeine.Auth.Tools;
    using Caffeine.Editor.Ext;
    using Caffeine.Editor.Nodes;
    using Caffeine.Runtime.Core.Config;
    using Caffeine.Runtime.Core.Models;
    using Caffeine.Runtime.Transfers;
    using Caffeine.Runtime.Transfers.Models;
    using Caffeine.Runtime.Transfers.Tokens;
    using Caffeine.Utilities;
    using Newtonsoft.Json;
    using UnityEngine;
    using System.Linq;
    using System.Collections.Generic;
    using Build.Protocol;
    using Build.Session;
    using Caffeine.Services;
    using Caffeine.Services.Content.Requests;


    public static class BuildUpload
    {
        public static async Task<bool> UploadBundleAssetForNode(string assetPath, string assetType, Node node)
        {
            Log($"Starting Asset Upload");

            var jwtPath = SessionManager.JWTPath;
            if (string.IsNullOrEmpty(jwtPath))
            {
                Log($"Failed Asset Upload - Session Inactive");
                return false;
            }

            Session.InitForBuilderWithJWTPath(jwtPath);
            await Config.InitEditorAsync(Application.dataPath, Application.temporaryCachePath, RapidSyncSetup.EditorEnvironment);
            
            var fileInfo = new FileInfo(assetPath);
            if (!fileInfo.Exists)
            {
                Log($"Failed Asset Upload - Asset Not Found");
                return false;
            }

            var remoteAsset = await GetAsset(assetType, node, assetPath).ConfigureAwait(true);
            if (remoteAsset == null)
            {
                Log($"Failed To Create Asset On Remote");
                return false; 
            }
            
            remoteAsset.Length = fileInfo.Length;
            remoteAsset.Name = assetType;

            Action<ITransfer, double> progressAction = (upload, progress) =>
            {
                // progress is a fraction in [0, 1] per the ITransfer.Progress
                // contract; the parent project's PublishPlatformCell parses the
                // -progress token straight into a 0–100 ProgressBar, so emit a
                // percentage on the wire.
                var percent = progress * 100.0;
                var summary = upload.Statistics.FormattedSummary("{rate} [ {progress} ] {eta}");
                StatusWriter.EmitUpload(summary, percent);
                LogUploadProgress($"-upload {summary} -progress {percent.ToString()}");
            };

            try
            {
                var completedAsset = await UploadAssetAsync(remoteAsset, assetPath, progressAction);
                if (completedAsset != null) await AssetCache.SetInstalledAsset(completedAsset);
                return completedAsset != null;
            }
            catch (Exception e)
            {
                Log(e.Message);
                return false;
            }
        }

        public static async Task<bool> UploadAssemblyAssetForNode(string assetType, Node node)
        {
            Log($"Starting Assembly Upload");

            var jwtPath = SessionManager.JWTPath;
            if (string.IsNullOrEmpty(jwtPath))
            {
                Log($"Failed Assembly Upload - Session Inactive");
                return false;
            }
            
            var assemblyAssetPath = Path.GetFullPath(Path.Combine(Paths.DataPath, "..", "Temporary", "CaffeinePlus.dll"));
            if (string.IsNullOrEmpty(assemblyAssetPath) || !File.Exists(assemblyAssetPath))
            {
                Log("Failed Assembly Upload - No Assembly Found");
                return false;
            }
            
            Session.InitForBuilderWithJWTPath(jwtPath);
            await Config.InitEditorAsync(Application.dataPath, Application.temporaryCachePath, RapidSyncSetup.EditorEnvironment);
            
            var fileInfo = new FileInfo(assemblyAssetPath);
            if (!fileInfo.Exists)
            {
                Log("Failed Assembly Upload - No Assembly Found");
                return false;
            }

            var remoteAsset = await GetAsset(assetType, node, assemblyAssetPath).ConfigureAwait(true);
            if (remoteAsset == null)
            {
                Log($"Failed To Create Assembly On Remote");
                return false; 
            }
            
            remoteAsset.Length = fileInfo.Length;
            remoteAsset.Name = assetType;

            Action<ITransfer, double> progressAction = (upload, progress) =>
            {
                // progress is a fraction in [0, 1] per the ITransfer.Progress
                // contract; the parent project's PublishPlatformCell parses the
                // -progress token straight into a 0–100 ProgressBar, so emit a
                // percentage on the wire.
                var percent = progress * 100.0;
                var summary = upload.Statistics.FormattedSummary("{rate} [ {progress} ] {eta}");
                StatusWriter.EmitUpload(summary, percent);
                LogUploadProgress($"-upload {summary} -progress {percent.ToString()}");
            };

            try
            {
                var completedAsset = await UploadAssetAsync(remoteAsset, assemblyAssetPath, progressAction);
                if (completedAsset != null) await AssetCache.SetInstalledAsset(completedAsset);
                return completedAsset != null;
            }
            catch (Exception e)
            {
                Log(e.Message);
                return false;
            }
        }
        
        public static async Task<Asset> GetAsset(string assetType, Node parentNode, string filePath)
        {
            // Fetch directly from API — BuildUpload runs in batch mode where AssetCache is unavailable,
            // and content/assembly asset types are not included in the editor cache.
            // A failed list must never be read as "no assets yet": that creates a duplicate asset of
            // this type on the node. Only a list the server actually answered may lead to a create.
            var assets = await FetchNodeAssetsAsync(parentNode);
            if (assets == null)
            {
                Log($"Could Not List Existing Assets - Not Creating A New Asset");
                return null;
            }

            try
            {
                var remoteAssets = assets.Where(i => i?.MetaData?.DataType == assetType).ToList();
                var asset = remoteAssets.FirstOrDefault();
                if (asset is { Id: > 0 }) { return asset; }
                
                var fileInfo = new FileInfo(filePath);
                var metaData = new AssetMetaData() { DataType = assetType };

                var assetCreate = new AssetCreate()
                {
                    NodeID = (int)parentNode.Id,
                    Name = $"{metaData.DataType}",
                    Length = fileInfo.Length,
                    MetaData = metaData
                };
                    
                return await assetCreate.CreateAssetAsync();
            }
            catch (Exception e)
            {
                Log(e.Message);
            }

            return null;
        }

        private static readonly int[] AssetListRetryDelaysMs = { 2000, 5000, 10000 };

        // Returns null when every attempt failed; a successful response with a null body is an empty list.
        private static async Task<List<Asset>> FetchNodeAssetsAsync(Node parentNode)
        {
            for (int attempt = 0; ; attempt++)
            {
                var response = await Adapter.ProcessRequestAsync(new NodeAssetListRequest { Node = parentNode });
                if (response is { Success: true, Exception: null })
                    return response.Value ?? new List<Asset>();

                var error = response?.ErrorMessage ?? response?.Exception?.Message ?? response?.Result?.StatusCode.ToString() ?? "no response";
                if (attempt >= AssetListRetryDelaysMs.Length)
                {
                    Log($"Asset List Failed: {error}");
                    return null;
                }

                Log($"Asset List Failed - Retrying ({error})");
                await Task.Delay(AssetListRetryDelaysMs[attempt]);
            }
        }

        public static async Task<Asset> UploadAssetAsync(Asset asset, string filePath, Action<ITransfer, double> progress)
        {
            using var upload = TransferFactory.CreateUpload(asset.Id, asset.Name, filePath);
            var course = UnityEngine.Object.FindObjectOfType<Caffeine.Runtime.Course.Course>();

            upload.SetMetadata(new AssetMetaData
            {
                EditorVersion   = Application.unityVersion,
                CaffeineVersion = Info.Version,
                Note            = course?.PublishSettings?.Notes ?? "",
            });

            upload.SetMetadata(new UploadContext
            {
                AssetId   = asset.Id.ToString(),
                AssetName = asset.Name ?? "",
                Version   = asset.Version.ToString(),
            });
            var uploadError = false;

            upload.Progress += progress;
            upload.Error += (TransferError error) =>
            {
                if (error.Kind == TransferErrorKind.Unauthorized)
                {
                    Log($"Transfer Token Expired - Retrying Upload");
                    Utilities.TransferTokens.DeleteTransferToken(filePath);
                }
                uploadError = true;
                StatusWriter.EmitUpload($"Upload Failed: {error.Message}", 0);
                LogUploadProgress($"-upload Upload Failed: {error.Message} -progress 0");
                Log($"Upload Error ({error.Kind}): {error.Message}");
            };

            var transferToken = Utilities.TransferTokens.GetTransferToken(filePath);

            if (transferToken == null)
            {
                await upload.StartAsync(async (string token) =>
                {
                    // Skip on Cancel only — Stop's final emit must reach disk so resume picks up.
                    if (upload.IsCancelled) return;
                    await Utilities.TransferTokens.SaveTransferToken(token, filePath);
                });

                return uploadError ? null : upload.CompletedAsset;
            }
            else
            {
                var uploadToken = JsonConvert.DeserializeObject<UploadToken>(transferToken);
                if (uploadToken != null && uploadToken.IsComplete)
                {
                    progress?.Invoke(upload, 1.0f);
                    return upload.CompletedAsset;
                }

                await upload.ResumeAsync(transferToken, async (string token) =>
                {
                    // Skip on Cancel only — Stop's final emit must reach disk so resume picks up.
                    if (upload.IsCancelled) return;
                    await Utilities.TransferTokens.SaveTransferToken(token, filePath);
                });

                return uploadError ? null : upload.CompletedAsset;
            }
        }
        
        private static void Log(string message)
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