using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace ApiBox.Api
{
    public abstract class ProgramBase<TStartup> where TStartup : class
    {
        public int Run(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting host");

                BootstrapWith<TStartup>(args)
                    .UseSerilog()
                    .Build()
                    .Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        protected virtual IWebHostBuilder BootstrapWith<TStartup>(string[] args) where TStartup : class
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<TStartup>();

        }
    }
}
