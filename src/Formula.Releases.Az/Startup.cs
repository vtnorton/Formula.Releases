using Formula.Releases.Az.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Formula.Releases.Az.Startup))]
namespace Formula.Releases.Az
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<FileServices>();
            builder.Services.AddSingleton<ReleaseServices>();
        }
    }
}
