using System;
using EIT.Context;
using EIT.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EIT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var hostingEnvironment = host.Services.GetService<IWebHostEnvironment>();
            var config = host.Services.GetRequiredService<IConfiguration>();
            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Application", hostingEnvironment?.ApplicationName ?? "EIT")
                .Enrich.WithProperty("DeploymentTarget", config["DEPLOYMENTTARGET"])
                .Enrich.FromLogContext();

            if (hostingEnvironment.IsDevelopment())
            {
                loggerConfiguration.WriteTo.Console();
            }

            Log.Logger = loggerConfiguration.CreateLogger();

            try
            {
                Log.Information("Run host");
                host.Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            //var dao = new CityDao(new RoutingContext());
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var deploymentTarget = hostingContext.Configuration["DEPLOYMENTTARGET"];
                    config.SetBasePath($"{Environment.CurrentDirectory}/Configuration");
                    config.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);
                    if (!string.IsNullOrEmpty(deploymentTarget))
                    {
                        Console.WriteLine($"Loading configurationfile for target >{deploymentTarget}<");
                        Log.Information($"Loading configurationfile for target >{deploymentTarget}<");
                        config.AddJsonFile($"appsettings.{deploymentTarget}.json", optional: false);
                    }
                    else
                    {
                        Console.WriteLine($"Unable to find configurationfile for target >{deploymentTarget}<");
                        Log.Information($"Unable to find configurationfile for target >{deploymentTarget}<");
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseKestrel();
                }).UseSerilog();
        }
    }
}
