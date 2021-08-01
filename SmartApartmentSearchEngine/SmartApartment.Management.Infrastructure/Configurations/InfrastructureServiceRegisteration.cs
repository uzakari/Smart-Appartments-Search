using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using SmartApartment.Management.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Infrastructure.Configurations
{
    public static class InfrastructureServiceRegisteration
    {

        public static IServiceCollection AddInfrastructureServcies(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddTransient<ISearchService, SearchServiceRepo>();

            services.AddTransient<IUploadService, UploadServiceRepo>();

            return services;
        }
    }
}
