using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System;
using Formula.Releases.Az.Services;

namespace Formula.Releases.Az
{
    public class Releases
    {
        private ReleaseServices _releaseServices;

        public Releases(ReleaseServices releaseServices) => _releaseServices = releaseServices;

        [FunctionName("Get")]
        public object Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ExecutionContext context)
        {
            try
            {
                return _releaseServices.GetReleases(context);
            }
            catch (Exception ex)
            {
                return $"Error:{ex.Message}";
            }
        }
    }
}
