using System;
namespace RimWorldModListing.Utilities
{
    public class ListingProcessor
    {
        private PlatformConfig paths;

        private ZipWrapper zip;
        private AwsWrapper aws;

        private string title;

        private bool doPackage;

        private bool doAws;
        private string namedProfile;
        private string s3Bucket;
        private string cFDistribution;

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

            this.paths = new PathManager().GetPlatformPaths();
            this.zip = new ZipWrapper();
            this.aws = new AwsWrapper();
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
            throw new NotImplementedException();
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
