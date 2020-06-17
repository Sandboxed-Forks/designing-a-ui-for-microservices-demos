﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sales.Api.Data;

namespace Sales.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddCors(options => { options.AddPolicy("AllowAllOrigins", builder => { builder.AllowAnyOrigin(); }); });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SalesContext.CreateSeedData();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseEndpoints(builder => builder.MapControllers());
        }
    }
}
