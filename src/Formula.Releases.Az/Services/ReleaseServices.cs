using Formula.Releases.Az.Model;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;

namespace Formula.Releases.Az.Services
{
    public class ReleaseServices
    {
        private string _baseUri;
        private FileServices _fileServices;

        public ReleaseServices(FileServices fileServices)
        {
            _fileServices = fileServices;
            _baseUri = Environment.GetEnvironmentVariable("BaseUri");
        }

        public List<Release> GetReleases(ExecutionContext context)
        {
            var fileArray = _fileServices.GetFileList(context);
            List<Release> releases = new List<Release>();

            for (int i = 0; i < fileArray.Length; i++)
            {
                string releaseName = _fileServices.GetReleaseName(fileArray[i]);

                if (!string.IsNullOrEmpty(releaseName))
                    releases.Add(new Release()
                    {
                        Id = i,
                        VersionName = releaseName,
                        Url = _baseUri + releaseName
                    });
            }

            return releases;
        }
    }
}
