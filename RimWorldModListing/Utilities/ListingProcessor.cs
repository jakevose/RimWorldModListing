using System;
using System.Collections.Generic;

namespace RimWorldModListing.Utilities
{
    public class ListingProcessor
    {
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

        private Dictionary<string, ModMeta> appliedMods;

        public ListingProcessor(string pageTitle,
                                bool packageFlag,
                                bool awsFlag,
                                string profile, string bucket, string distribution)
        {
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

            appliedMods = new Dictionary<string, ModMeta>();
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

        }

        private void MapModsConfigToFilePaths()
        {
            throw new NotImplementedException();
        }

        private void ClearOutputDirectory()
        {
            throw new NotImplementedException();
        }

        private void ArchiveMods()
        {
            throw new NotImplementedException();
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
