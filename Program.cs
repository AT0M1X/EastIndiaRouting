using System;
using FTOP.Serilog.Configuration;
using FTOP.Serilog.Sink.BatchFormatter;
using FTOP.Serilog.Sink.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Elasticsearch;

namespace EIT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var hostingEnvironment = host.Services.GetService<IWebHostEnvironment>();
            var serilogConfiguration = host.Services.GetService<SerilogNagiosConfiguration>();
            var config = host.Services.GetRequiredService<IConfiguration>();
            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Application", hostingEnvironment?.ApplicationName ?? "EIT")
                .Enrich.WithProperty("DeploymentTarget", config["DEPLOYMENTTARGET"])
                .Enrich.FromLogContext();

            if (!string.IsNullOrEmpty(serilogConfiguration?.File))
            {
                loggerConfiguration.WriteTo.File(new ElasticsearchJsonFormatter(), serilogConfiguration.File, rollingInterval: RollingInterval.Hour);
            }

            if (!string.IsNullOrEmpty(serilogConfiguration?.NagiosUri))
            {
                loggerConfiguration.WriteTo.DurableHttpUsingFileSizeRolledBuffers(
                    requestUri: serilogConfiguration.NagiosUri,
                    httpClient: new TcpHttpClient(),
                    bufferBaseFileName: serilogConfiguration.BufferFilename,
                    batchFormatter: new NagiosLogstashBatcher(),
                    period: serilogConfiguration.BatchInterval,
                    textFormatter: new ElasticsearchJsonFormatter());
            }

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
                        .UseSerilog()
                        .UseKestrel();
                });
        }
    }
}
