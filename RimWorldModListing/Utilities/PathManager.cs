using System;
using System.IO;

namespace RimWorldModListing.Utilities
{
    public class PathManager
    {
        private PlatformConfig config;

        public PathManager()
        {
            config = GetPlatformPaths();
        }

        public PlatformConfig GetPaths()
        {
            return config;
        }

        public bool ValidPaths()
        {
            return Directory.Exists(config.gameModsPath) &&
                   Directory.Exists(config.workshopPath) &&
                   File.Exists(config.modsConfigPath);
        }

        private PlatformConfig GetPlatformPaths()
        {
            string homePath;

            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                case PlatformID.Unix:
                    homePath = Environment.GetEnvironmentVariable("HOME");

                    return new PlatformConfig(
                        Path.Combine(homePath, "Library/Application Support/Steam/steamapps/common/RimWorld/RimWorldMac.app/Mods"),
                        Path.Combine(homePath, "Library/Application Support/Steam/steamapps/workshop/content/294100"),
                        Path.Combine(homePath, "Library/Application Support/RimWorld/Config/ModsConfig.xml")
                    );
                default:
                    homePath = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

                    return new PlatformConfig(
                        "c:\\Program Files (x86)\\Steam\\steamapps\\common\\RimWorld\\Mods",
                        "c:\\Program Files (x86)\\Steam\\steamapps\\workshop\\content\\294100",
                        Path.Combine(homePath, "AppData\\LocalLow\\Ludeon Studios\\RimWorld by Ludeon Studios\\Config\\ModsConfig.xml")
                    );
            }
        }
    }
}
