using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;
using Prometheus.DotNetRuntime;

namespace QueroSolucao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Coletor de m�tricas 
            Collector = CreateCollector();
        }

        public IConfiguration Configuration { get; }

        public static IDisposable Collector;

        // M�todo para adicionar servidos ao container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // M�todo para configurar solicita��es HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                
                app.UseHsts();
            }

            //Adi��o de Endpoints para coleta

            app.UseHttpMetrics();

            app.UseMetricServer();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();                
            });
        }

        //M�todo que coleta m�tricas da aplica��o
        public static IDisposable CreateCollector()
        {
            var builder = DotNetRuntimeStatsBuilder.Default();
            builder = DotNetRuntimeStatsBuilder.Customize()
                .WithContentionStats(CaptureLevel.Informational)
                .WithGcStats(CaptureLevel.Verbose)
                .WithThreadPoolStats(CaptureLevel.Informational)
                .WithExceptionStats(CaptureLevel.Errors)
                .WithJitStats();

            builder.RecycleCollectorsEvery(new TimeSpan(0, 10, 0));

            return builder
                .StartCollecting();
        }



    }
}
