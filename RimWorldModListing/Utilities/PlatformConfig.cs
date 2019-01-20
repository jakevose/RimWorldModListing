using System;
namespace RimWorldModListing.Utilities
{
    public struct PlatformConfig
    {
        public string gameModsPath, workshopPath, modsConfigPath;

        public PlatformConfig(string gameMods, string workshop, string modsConfig)
        {
            gameModsPath = gameMods;
            workshopPath = workshop;
            modsConfigPath = modsConfig;
        }
    }
}
