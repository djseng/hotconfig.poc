using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//configure.AddAzureKeyVault("https://hotconfig-poc-kv.vault.azure.net/");
var hostBuilder = new HostBuilder();
hostBuilder
    .ConfigureHostConfiguration(
        configure => configure.AddJsonFile("appconfig.json", false))
    .ConfigureServices(
        (ctx, services) =>
        {
            services.AddLogging(lb => lb.AddConfiguration(ctx.Configuration));
            services.AddHttpClient();
            services.AddHostedService<ProofOfConceptService>();
        });
var host = hostBuilder.Build();
try
{
    await host.RunAsync();
}
finally
{
    host.Dispose();
}
