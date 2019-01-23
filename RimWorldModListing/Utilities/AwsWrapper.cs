using System;
using System.IO;
using System.Collections.Generic;

using Amazon.S3;
using Amazon.CloudFront;
using Amazon.Runtime;
using Amazon;

namespace RimWorldModListing.Utilities
{
    public class AwsWrapper
    {
        private MainWindow win;
        private AmazonS3Client s3;
        private AmazonCloudFrontClient cf;

        string s3Bucket;

        public AwsWrapper(MainWindow window, string profile, string bucket)
        {
            win = window;

            try
            {
                var credentials = new StoredProfileAWSCredentials(profile);
                s3 = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
                cf = new AmazonCloudFrontClient(credentials, RegionEndpoint.USEast1);

                s3Bucket = bucket;
            }
            catch (Exception e)
            {
                window.LogLine(e.Message);
                throw;
            }
        }

        public void UploadFiles(string modsConfigPath, string zipFile)
        {
            win.LogLine($"Uploading HTML index page...");
            pushFile("index.html", Path.Combine("Output", "index.html"));

            if (zipFile == null)
            {
                win.LogLine("Pushed HTML index page.");
            }
            else
            {
                win.LogLine($"Pushed HTML index page. Uploading {zipFile}...");
                pushFile("rimworld-mods.zip", zipFile);

                win.LogLine($"Pushed {zipFile}. Pushing ModsConfig.xml...");
                pushFile("ModsConfig.xml", modsConfigPath);

                win.LogLine($"Pushed ModsConfig.xml.");
            }
        }

        private void pushFile(string filename, string path)
        {
            s3.PutObject(new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = s3Bucket,
                Key = filename,
                FilePath = path
            });

            s3.PutACL(new Amazon.S3.Model.PutACLRequest
            {
                BucketName = s3Bucket,
                Key = filename,
                CannedACL = S3CannedACL.Private
            });

        }
    }
}
