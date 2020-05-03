using Formula.Releases.Wordpress.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

[assembly: FunctionsStartup(typeof(Formula.Releases.Wordpress.Startup))]
namespace Formula.Releases.Wordpress
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<AzReleaseServices>();
            builder.Services.AddSingleton<WordPressServices>();
        }
    }
}