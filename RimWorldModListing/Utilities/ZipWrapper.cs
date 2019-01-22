using System;

using System.IO;

using System.Collections.Generic;

using System.Linq;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace RimWorldModListing.Utilities
{
    public class ZipWrapper
    {
        private MainWindow win;

        private static string zipFilePath = Path.Combine("Output", "rimworld-mods.zip");
        private static string[] excludePaths = new string[] { ".git", ".idea", ".vs", "Source" };

        public ZipWrapper(MainWindow window)
        {
            win = window;
        }

        public string ArchiveMods(Dictionary<string, ModMeta> appliedModsMapping)
        {
            FileStream fsOut = File.Create(zipFilePath);

            using (ZipOutputStream zipStream = new ZipOutputStream(fsOut))
            {
                zipStream.SetLevel(5);

                foreach (string mod in appliedModsMapping.Keys)
                {
                    ModMeta meta = appliedModsMapping[mod];

                    win.LogLine($"Zipping: {meta.name} ({mod})...");

                    ArchiveMod(zipStream, meta, mod);
                }
            }

            win.LogLine("Zipfile creation complete.");

            return zipFilePath;
        }

        private void ArchiveMod(ZipOutputStream zipStream, ModMeta meta, string relativePath)
        {
            foreach (string filePath in Directory.GetFiles(Path.Combine(meta.path, relativePath)))
            {
                string filename = Path.GetFileName(filePath);
                ZipEntry newEntry = new ZipEntry(Path.Combine(relativePath, filename));

                FileInfo fi = new FileInfo(filePath);
                newEntry.DateTime = fi.LastWriteTime;
                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filePath))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }

            foreach (string directoryPath in Directory.GetDirectories(Path.Combine(meta.path, relativePath)))
            {
                DirectoryInfo directory = new DirectoryInfo(directoryPath);

                if (!excludePaths.Contains(directory.Name))
                {
                    ArchiveMod(zipStream, meta, Path.Combine(relativePath, directory.Name));
                }
            }
        }
    }
}
