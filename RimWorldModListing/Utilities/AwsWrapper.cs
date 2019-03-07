using System;
using System.IO;
using System.Collections.Generic;

using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace RimWorldModListing.Utilities
{
    public class AwsWrapper
    {
        private MainWindow win;
        private AmazonS3Client s3;
        private AmazonCloudFrontClient cf;

        string s3Bucket;
        string cfDistribution;

        public AwsWrapper(MainWindow window, string profile, string bucket, string distribution)
        {
            win = window;

            try
            {
                var credentials = new StoredProfileAWSCredentials(profile);
                s3 = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
                cf = new AmazonCloudFrontClient(credentials, RegionEndpoint.USEast1);

                s3Bucket = bucket;
                cfDistribution = distribution;
            }
            catch (Exception e)
            {
                win.LogLine(e.Message);
                throw;
            }
        }

        public void UploadFiles(string modsConfigPath, string zipFile)
        {
            win.LogLine($"Uploading HTML index page...");

            try
            {
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
            catch (Exception e)
            {
                win.LogLine(e.Message);
                throw;
            }
        }

        public void RefreshCloudFrontDistribution()
        {
            if (cfDistribution != null && cfDistribution.Length > 5)
            {
                RefreshExistingCloudFrontDistribution();
            }
        }

        private void pushFile(string filename, string path)
        {
            s3.PutObject(new PutObjectRequest
            {
                BucketName = s3Bucket,
                Key = filename,
                FilePath = path
            });

            s3.PutACL(new PutACLRequest
            {
                BucketName = s3Bucket,
                Key = filename,
                CannedACL = S3CannedACL.Private
            });
        }

        private void RefreshExistingCloudFrontDistribution()
        {
            try
            {
                InvalidationBatch newInvalidationBatch = new InvalidationBatch();

                newInvalidationBatch.Paths.Quantity = 1;
                newInvalidationBatch.Paths.Items = new List<string> { "/*" };

                newInvalidationBatch.CallerReference = $"website_update_{DateTime.Now.ToShortDateString()}";

                cf.CreateInvalidation(new CreateInvalidationRequest
                {
                    DistributionId = cfDistribution,
                    InvalidationBatch = newInvalidationBatch
                });

                GetDistributionResponse distResponse = cf.GetDistribution(new GetDistributionRequest
                {
                    Id = cfDistribution
                });

                win.LogLine($"Distribution refreshed, URL reminder: {distResponse.Distribution.DomainName}");
            }
            catch (Exception e)
            {
                win.LogLine(e.Message);
                throw;
            }
        }
    }
}
