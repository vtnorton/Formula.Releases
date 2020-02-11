using Microsoft.Azure.WebJobs;
using System;
using System.IO;

namespace Formula.Releases.Az.Services
{
    public class FileServices
    {

        public string[] GetFileList(ExecutionContext context)
        {
            try
            {
                return Directory.GetFiles(context.FunctionAppDirectory + "/Data", "*.md");
            }
            catch (Exception ex)
            {
                throw;
            }
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
