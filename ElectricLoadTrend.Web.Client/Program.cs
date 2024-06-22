using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ElectricLoadTrend.Web.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        await builder.Build().RunAsync();
        
    }
}
