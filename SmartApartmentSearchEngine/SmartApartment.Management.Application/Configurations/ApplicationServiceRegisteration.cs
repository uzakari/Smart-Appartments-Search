using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using MediatR;

namespace SmartApartment.Management.Application.Configurations
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
