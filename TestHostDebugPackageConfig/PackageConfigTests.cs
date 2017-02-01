using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace TestHostDebugPackageConfig
{
    public class PackageConfigTests
    {
        public class StartupMock : IStartup
        {
            public IServiceProvider ConfigureServices(IServiceCollection services)
            {
                return services.BuildServiceProvider();
            }

            public void Configure(IApplicationBuilder app)
            {
            }
        }

        [Fact]
        public void create_client()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<StartupMock>());
            var client = server.CreateClient();
        }
    }
}