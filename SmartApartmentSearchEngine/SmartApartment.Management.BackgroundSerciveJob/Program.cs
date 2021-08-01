using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartApartment.Management.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartment.Management.BackgroundSerciveJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddInfrastructureServcies(hostContext);

                    services.AddHostedService<SearchUploadProcessor>();
                });
    }
}
