#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Build
{
    using System.IO;
    using Caffeine.Editor.Utilities;
    using SharpCompress.Common;
    using SharpCompress.Readers;

    public class PackageExtractor
    {
        public static void ExtractPackage(string packagePath, string outputDir)
        {
            using var stream = File.OpenRead(packagePath);
            using var reader = ReaderFactory.Open(stream);
        
            while (reader.MoveToNextEntry())
            {
                if (!reader.Entry.IsDirectory && !ArchiveUtilities.ShouldSkipArchiveEntry(reader.Entry.Key))
                {
                    reader.WriteEntryToDirectory(outputDir, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }
    }
}
#endif