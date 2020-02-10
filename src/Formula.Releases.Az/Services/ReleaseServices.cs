using Formula.Releases.Az.Model;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Formula.Releases.Az.Services
{
    public class ReleaseServices
    {
        private string _baseUri;
        private ExecutionContext _context;

        public ReleaseServices(ExecutionContext context)
        {
            _baseUri = Environment.GetEnvironmentVariable("BaseUri");
            _context = context;
        }

        public List<Release> GetReleases()
        {
            var fileArray = GetFileList();
            List<Release> releases = new List<Release>();

            for (int i = 0; i < fileArray.Length; i++)
            {
                string releaseName = GetReleaseName(fileArray[i]);

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

        public string[] GetFileList()
        {
            return Directory.GetFiles(_context.FunctionAppDirectory + "/Data", "*.md");
        }

        public string GetReleaseName(string path)
        {
            if (!path.Contains(".md") && !path.Contains(@"\"))
                return null;

            int mdIndex = path.IndexOf(".md");
            return path.Remove(mdIndex, 3).Substring(path.LastIndexOf(@"\")).Remove(0, 1);
        }
    }
}
