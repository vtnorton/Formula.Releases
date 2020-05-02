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
                var filePath = fileArray[i];
                string releaseName = _fileServices.GetReleaseName(filePath);

                if (!string.IsNullOrEmpty(releaseName))
                {
                    var content = _fileServices.GetContentInfo(filePath);
                    releases.Add(new Release()
                    {
                        Id = i,
                        VersionName = releaseName,
                        Url = _baseUri + releaseName,
                        Description = content["Description"].ToString(),
                        ReleaseDate = content["ReleaseDate"].ToString(),
                        IsPreview =  bool.Parse(content["IsPreview"].ToString())
                    });
                }
            }

            return releases;
        }
    }
}
