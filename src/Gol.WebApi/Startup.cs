using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Gol.Domain.Interfaces.Repository;
using Gol.Domain.Interfaces.Service;
using Gol.Infra.Data.DataContext;
using Gol.Infra.Data.Repositories;
using Gol.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Gol.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Context
            services.AddScoped<GolAirlinesContext, GolAirlinesContext>();

            //Services
            services.AddTransient<AirplaneService, AirplaneService>();
            services.AddTransient<IAirplaneService, AirplaneService>();

            //Repository
            services.AddTransient<AirplaneRepository, AirplaneRepository>();
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Gol Airlines", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo("pt-BR") },
                DefaultRequestCulture = new RequestCulture("pt-BR")
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gol Airlines Api - V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseMvc();
        }
    }
}
