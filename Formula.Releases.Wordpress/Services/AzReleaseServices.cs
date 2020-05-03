using Formula.Releases.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Formula.Releases.Wordpress.Services
{
    public class AzReleaseServices
    {
        private static HttpClient _client;
        public IDictionary<string, Release> Releases = new Dictionary<string, Release>();

        public AzReleaseServices(HttpClient httpClient)
        {
            _client = new HttpClient();
        }

        public async Task<List<string>> GetReleases()
        {
            HttpResponseMessage response = await _client.GetAsync(Environment.GetEnvironmentVariable("ChangelogAPI"));

            if (!response.IsSuccessStatusCode)
                throw new OperationCanceledException();

            var content = await response.Content.ReadAsStringAsync();
            var releases = JsonConvert.DeserializeObject<List<Release>>(content);
            var releasesAsString = new List<string>();

            foreach (var item in releases)
            {
                Releases.Add(item.VersionName, item);
                releasesAsString.Add(item.VersionName);
            }

            return releasesAsString;
        }
    }
}
