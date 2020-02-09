using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System;
using Formula.Releases.Az.Services;

namespace Formula.Releases.Az
{
    public static class Releases
    {
        [FunctionName("Get")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ExecutionContext context)
        {
            try
            {
                ReleaseServices releaseServices = new ReleaseServices(context);
                return releaseServices.GetReleases();
            }
            catch (Exception ex)
            {

                return $"Error:{ex.Message}";
            }
        }
    }
}
