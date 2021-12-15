using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forecast.API.Mapper;
using Forecast.Application.UseCases.GetForecast;
using Forecast.Application.UseCases.GetHistory;
using Forecast.Domain.Abstractions;
using Forecast.Persistence.Contexts;
using Forecast.Persistence.UseCases;
using Forecast.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Forecast.API
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

            services.AddCors(o => o.AddPolicy("_allowedOrigins", builder =>
            {
                builder.WithOrigins("http://localhost:8080/")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc();
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "Forecast API", Version = "v1" });
            });
            services.AddMediatR(typeof(GetForecastUseCase), typeof(GetHistoryUseCase));
            services.AddDbContext<HistoryContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services
                .AddScoped<IDataMapper, DataMapper>()
                .AddScoped<IForecastPersistence, ForecastPersistence>()
                .AddScoped(typeof(IHistoryPersistence<>), typeof(HistoryPersistence<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast API");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("_allowedOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
       
        }
    }
}
