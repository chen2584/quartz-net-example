using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;

namespace MyWeb
{
    public class Startup
    {
        readonly IScheduler _quartzSceduler;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _quartzSceduler = ConfigureQuartz();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IScheduler>(_quartzSceduler);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime hostApplicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            hostApplicationLifetime.ApplicationStopping.Register(() => OnShutDown());
        }

        private void OnShutDown()
        {
            if (!_quartzSceduler.IsShutdown)
            {
                _quartzSceduler.Shutdown();
            }
            Console.WriteLine("Hello World!");
        }

        private IScheduler ConfigureQuartz()
        {
            var collection = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            
            var factory = new StdSchedulerFactory(collection);
            var scheduler = factory.GetScheduler().Result;
            scheduler.Start().Wait();
            return scheduler;
        }
    }
}
