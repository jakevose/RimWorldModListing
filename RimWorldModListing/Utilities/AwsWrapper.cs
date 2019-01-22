using System;
using System.Collections.Generic;

namespace RimWorldModListing.Utilities
{
    public class AwsWrapper
    {
        private MainWindow win;

        public AwsWrapper(MainWindow window)
        {
            win = window;
        }

        public void UploadFiles(Dictionary<string, ModMeta> appliedModsMapping, string zipFile)
        {
            throw new NotImplementedException();
        }
    }
}
