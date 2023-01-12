using System;
using EIT.Model.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EIT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appconfig = Configuration.GetSection("ApplicationConfiguration").Get<ApplicationConfiguration>();
            services.AddSingleton(appconfig);
            services.AddSingleton(Configuration.GetSection("ReactClientConfiguration").Get<ReactClientConfiguration>());

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.ForwardLimit = 2; //Antal proxy-hop (Docker containeren taeller som en)
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MainPolicy", builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    //.WithOrigins(<Array of corsenabled urls>) // Indsættes fra config.
                    ;
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EIT", Version = "v1" });
            });

            if (appconfig.EnableReactDevelopmentServer)
                services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ReactApp/build"; });
            else
                services.AddSpaStaticFiles(configuration => configuration.RootPath = @"wwwroot");

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, ApplicationConfiguration config)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EIT v1"));
            }

            app.UseForwardedHeaders();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseCors("MainPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSpa(spa =>
            {
                if (config.EnableReactDevelopmentServer)
                {
                    spa.Options.SourcePath = "ReactApp";
                    spa.UseReactDevelopmentServer("start");
                }
            });

        }
    }
}
