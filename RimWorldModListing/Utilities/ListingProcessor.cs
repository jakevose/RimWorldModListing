using System;

using System.IO;

using System.Collections.Generic;

using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace RimWorldModListing.Utilities
{
    public class ListingProcessor
    {
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

            if (packageFlag) { zip = new ZipWrapper(window); }
            if (awsFlag) { aws = new AwsWrapper(window); }

            listedMods = new List<string>();
            appliedModsMapping = new Dictionary<string, ModMeta>();
        }

        public void Run() {

            LoadModFileListings();

            MapModsConfigToFilePaths();

            ClearOutputDirectory();

            string zipFile = null;
            if (zip != null)
            {
                zipFile = zip.ArchiveMods(appliedModsMapping); ;
            }

            GenerateHtmlListing();

            if (aws != null) {
                aws.UploadFiles(appliedModsMapping, zipFile);
            }
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

        private void GenerateHtmlListing()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(
$@"<html>
  <head>
    <title>{title}</title>
  </head>
  <body>
");

            if (title != null && title != "")
            {
                builder.Append(
$@"    <h1>{title}</h1>
");
            }

            builder.Append(
@"    <ol>
");

            foreach (string mod in appliedModsMapping.Keys)
            {
                ModMeta meta = appliedModsMapping[mod];

                if (meta.workshop != null)
                {
                    builder.Append(
$@"      <li><a target='_blank\' href='{meta.workshop}'>{meta.name}</a> <i>by {meta.author}</i></li>
");
                }
                else
                {
                    builder.Append(
$@"      <li>{meta.name} <i>by {meta.author}</i></li>
");
                }
            }

            builder.Append(
@"    </ol>
");

            //builder.Append(DownloadLinks());

            builder.Append(
$@"    <br/><br/>
    <i>Last updated: {DateTime.Now.ToLongDateString()}</i>
  </body>
</html>
");

            File.WriteAllText(Path.Combine("Output", "index.html"), builder.ToString());

            window.LogLine("HTML generation completed.");
        }
    }
}
