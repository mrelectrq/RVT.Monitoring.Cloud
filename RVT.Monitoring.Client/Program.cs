using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RVT.Monitoring.Client.Security;
using RVT.Monitoring.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = Config.IDENTITY_HOST;
                options.ProviderOptions.ClientId = Config.CLIENT_ID_BLAZOR;
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.DefaultScopes.Add("rvt.profile");
                options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:5001/";
                options.UserOptions.RoleClaim = "role";
            }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();



            builder.Services.AddHttpClient("api").AddHttpMessageHandler(opt =>
            {
                var handler = opt.GetService<AuthorizationMessageHandler>().ConfigureHandler(authorizedUrls: new[] { "https://localhost:44386" },
                                    scopes: new[] {"api1"});
                
                return handler;
            });

            builder.Services.AddScoped(opt => opt.GetRequiredService<IHttpClientFactory>().CreateClient("api"));


            await builder.Build().RunAsync();
        }
    }
}
