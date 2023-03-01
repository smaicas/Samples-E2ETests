using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace ContactForm.Tests;

public class DnjTestingWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseUrls("https://localhost:7048");
        builder.ConfigureAppConfiguration(config => config.Sources.Clear());
    }
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // need to create a plain host that we can return.
        IHost dummyHost = builder.Build();

        // configure and start the actual host.
        builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());

        IHost host = builder.Build();
        host.Start();

        return dummyHost;
    }
}