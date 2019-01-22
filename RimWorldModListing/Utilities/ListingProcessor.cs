using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;
using System.Xml.Linq;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace RimWorldModListing.Utilities
{
    public class ListingProcessor
    {
        private static string[] excludePaths = new string[] { ".git", ".idea", ".vs", "Source" };

        private MainWindow window;

        private PathManager pathManager;
        private PlatformConfig paths;

        private ZipWrapper zip;
        private AwsWrapper aws;

        private string title;

        private bool doPackage;

        private bool doAws;
        private string namedProfile;
        private string s3Bucket;
        private string cFDistribution;

        private List<string> listedMods;
        private Dictionary<string, ModMeta> appliedModsMapping;

        public ListingProcessor(MainWindow mainWindow,
                                string pageTitle,
                                bool packageFlag,
                                bool awsFlag,
                                string profile, string bucket, string distribution)
        {
            window = mainWindow;
            title = pageTitle;
            doPackage = packageFlag;
            doAws = awsFlag;
            namedProfile = profile;
            s3Bucket = bucket;
            cFDistribution = distribution;

            pathManager = new PathManager();
            paths = pathManager.GetPaths();
            zip = new ZipWrapper();
            aws = new AwsWrapper();

            listedMods = new List<string>();
            appliedModsMapping = new Dictionary<string, ModMeta>();
        }

        public void Run() {

            LoadModFileListings();

            MapModsConfigToFilePaths();

            ClearOutputDirectory();

            if (zip != null) { ArchiveMods(); }

            if (aws != null) { UploadFiles(); }

            GenerateHtmlListing();
        }

        private void LoadModFileListings()
        {
            if (pathManager.ValidPaths())
            {
                window.LogLine("Paths validate, fetching listings...");

                XElement root = XElement.Load(paths.modsConfigPath);
                IEnumerable<String> mods =
                    from li in root.Descendants("li")
                    select (string)li;
                foreach (string mod in mods)
                {
                    if (mod != "Core")
                    {
                        listedMods.Add(mod);
                    }
                }

                window.LogLine($"{mods.Count()} mods loaded.");
            } else
            {
                throw new ApplicationException("There's something wrong with the mod/config paths, please report this error!");
            }
        }

        private void MapModsConfigToFilePaths()
        {
            var gameDirMods = Directory.EnumerateDirectories(paths.gameModsPath).Select(p => Path.GetFileName(p));
            var workshopMods = Directory.EnumerateDirectories(paths.workshopPath).Select(p => Path.GetFileName(p));

            foreach (string mod in listedMods)
            {
                string foundPath = null;
                if (mod != "Core" && gameDirMods.Contains(mod))
                {
                    foundPath = paths.gameModsPath;
                }
                else if (workshopMods.Contains(mod))
                {
                    foundPath = paths.workshopPath;
                }
                else
                {
                    window.LogLine($"WARN: mod listed, but location not found: {mod}");
                }

                if (foundPath != null)
                {
                    XElement root = XElement.Load(Path.Combine(foundPath, mod, "About", "About.xml"));
                    string name = root.Element("name").Value;
                    string author = root.Element("author").Value;

                    appliedModsMapping.Add(mod, new ModMeta(mod, paths.workshopPath, name, author, mod));
                }
            }
        }

        private void ClearOutputDirectory()
        {
            if (Directory.Exists("Output"))
            {
                Directory.Delete("Output", true);
                window.LogLine("Output directory destroyed.");
            }

            Directory.CreateDirectory("Output");

            window.LogLine("Output directory recreated.");
        }

        private void ArchiveMods()
        {
            FileStream fsOut = File.Create(Path.Combine("Output", "rimworld-mods.zip"));
            using (ZipOutputStream zipStream = new ZipOutputStream(fsOut))
            {
                zipStream.SetLevel(5);

                foreach (string mod in appliedModsMapping.Keys)
                {
                    ModMeta meta = appliedModsMapping[mod];

                    window.LogLine($"Zipping: {mod}...");

                    ArchiveMod(zipStream, meta, mod);
                }
            }

            window.LogLine("Zipfile creation complete.");
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

                window.LogLine($"Zipped: {filePath}");
            }

            foreach (string directoryPath in Directory.GetDirectories(Path.Combine(meta.path, relativePath)))
            {
                DirectoryInfo directory = new DirectoryInfo(directoryPath);

                if (!excludePaths.Contains(directory.Name)) {
                    ArchiveMod(zipStream, meta, Path.Combine(relativePath, directory.Name));
                }
            }
        }

        private void UploadFiles()
        {
            throw new NotImplementedException();
        }

        private void GenerateHtmlListing()
        {
            throw new NotImplementedException();
        }
    }
}
