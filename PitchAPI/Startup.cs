using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

using PitchAPI.Extensions;
using System.IO;

namespace PitchAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // give NLog LogManager the config file
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // adds service to DI container
        public void ConfigureServices(IServiceCollection services)
        {
            // call static configuration methods from ServiceExtensions
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            // configure logger
            services.ConfigureLoggerService();

            // configure MySQL DB
            services.ConfigureMySqlContext(Configuration);

            // configure repos
            services.ConfigureRepositoryWrapper();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            // forward proxy headers to the current request
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
