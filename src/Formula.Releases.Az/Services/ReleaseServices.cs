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
            List<Release> releases = new List<Release>();
            string[] fileArray = Directory.GetFiles(_context.FunctionAppDirectory + "/Data", "*.md");

            for (int i = 0; i < fileArray.Length; i++)
            {
                string fileName = fileArray[i];
                if (fileName.Contains(".md") && fileName.Contains(@"\"))
                {
                    int mdIndex = fileName.IndexOf(".md");
                    string versionName = fileName.Remove(mdIndex, 3).Substring(fileName.LastIndexOf(@"\")).Remove(0, 1);

                    releases.Add(new Release()
                    {
                        Id = i,
                        VersionName = versionName,
                        Url = _baseUri + versionName
                    });
                }
            }

            return releases;
        }
    }
}
