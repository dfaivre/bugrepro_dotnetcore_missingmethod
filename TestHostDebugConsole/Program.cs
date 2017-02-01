using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        var client = server.CreateClient();

        Console.WriteLine("client created!.  Press any key.");
    }
}

public class Startup : IStartup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        return services.BuildServiceProvider();
    }

    public void Configure(IApplicationBuilder app)
    {
        return;
    }
}