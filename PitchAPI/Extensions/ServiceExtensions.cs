using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Contracts;
using LoggerService;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace PitchAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            // gives clients on a different domain access to the API
            // alloq any origin, method, and header
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                     builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
            });

        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            // create a singleton LoggerManager so we can re-use the service
            // tell DI that whenever we ask for an ILoggerManager, return a LoggerManager
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            // establish connection to MySql and add to DI container
            var connectionString = config["mysqlconnections:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            // every time we need an IRepositoryWrapper, we provide RepositoryWrapper
            // RepositoryWrapper provides a repository for each model class
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
