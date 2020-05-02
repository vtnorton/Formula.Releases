using Formula.Releases.Az.Extention;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public IDictionary<string, object> GetContentInfo(string path)
        {
            var dictionary = new Dictionary<string, object>();

            if (File.Exists(path))
            {
                using (StreamReader inputStream = new StreamReader(path))
                {
                    var content = inputStream.ReadToEnd();
                    if(content.Contains("<!--Brief description: "))
                        dictionary.Add("Description", content.GetBetween("<!--Brief description: ", ")-->"));

                    if (content.Contains("<!--Released at: "))
                        dictionary.Add("ReleaseDate", content.GetBetween("<!--Released at: ", ")-->"));
                }
            }

            dictionary.Add("IsPreview", path.Contains("-preview"));

            return dictionary;
        }
    }
}
