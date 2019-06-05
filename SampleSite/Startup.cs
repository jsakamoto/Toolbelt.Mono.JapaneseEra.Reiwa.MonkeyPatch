using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Toolbelt.Mono.Globalization;

namespace SampleSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            JapaneseEraMonkeyPatch.EnableReiwa();
            app.UseLocalTimeZone();
            app.AddComponent<App>("app");
        }
    }
}
