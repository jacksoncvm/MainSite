using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Steeltoe.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<ICalendarEvents, CalendarEvents>();
            builder.Services.AddSingleton<IParseFromMarkdown, ParseFromMarkdown>();
            builder.Services.AddSingleton<IDocsSite, DocsSite>();

            await builder.Build().RunAsync();
        }
    }
}
