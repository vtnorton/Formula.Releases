using Formula.Releases.Wordpress.Services;
using Microsoft.Azure.WebJobs;
using System.Linq;

namespace Formula.Releases.Wordpress
{
    public class Connection
    {
        private AzReleaseServices _azReleaseServices;
        private WordPressServices _wordPressServices;

        public Connection(AzReleaseServices azReleaseServices, WordPressServices wordPressServices)
        {
            _azReleaseServices = azReleaseServices;
            _wordPressServices = wordPressServices;
        }

        // Ir� rodar todo dia 9:30 da manh�
        [FunctionName("UpdateDB")]
        public async void Run([TimerTrigger("*/15 * * * * *")]TimerInfo timer)
        {
            var releases = await _azReleaseServices.GetReleases();
            var posts = _wordPressServices.GetPosts();

            foreach (var item in releases.Except(posts).ToList())
            {
                _wordPressServices.Post(_azReleaseServices.Releases[item]);
            }
        }
    }
}
