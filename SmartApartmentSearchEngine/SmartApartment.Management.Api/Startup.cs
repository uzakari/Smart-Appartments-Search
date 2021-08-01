using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartApartment.Management.Api.Middleware;
using SmartApartment.Management.Application.Configurations;
using SmartApartment.Management.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartment.Management.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });


            services.AddApplicationServices();

            // health checks added for ci/cd if it's ok to rout https request
            services.AddHealthChecks();


            services.AddInfrastructureServcies(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartApartment.Management.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartApartment.Management.Api v1"));
            }

            app.UseCustomExceptionHandler();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // this will return a 200 status to ensure the servcie can handle http request
                endpoints.MapHealthChecks("/health/live");

                endpoints.MapControllers();
            });
        }
    }
}
