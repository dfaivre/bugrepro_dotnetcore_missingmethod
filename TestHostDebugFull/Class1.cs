using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace TestHostDebugFull
{
    public class Class1
    {
        [Fact]
        public void create_client()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<StartupMock>());
            var client = server.CreateClient();
        }

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
    }
}
