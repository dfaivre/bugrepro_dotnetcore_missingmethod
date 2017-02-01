using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace TestHostDebugNetCore
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = server.CreateClient();
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
}
