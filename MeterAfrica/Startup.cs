using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MeterAfrica.Data;
using MeterAfricaClassLib.Services;
using MeterAfricaClassLibrary.Utilities;
using MeterAfrica.Data.MeterAfricaServices;
using Blazored.SessionStorage;

namespace MeterAfrica
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredSessionStorage();
            services.AddTransient<ProcessMeterService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IBaseHttpClient, BaseHttpClient>();
            

            services.AddSingleton(Configuration.GetSection("AppSettings").Get<AppSettings>());
            services.AddSingleton(Configuration.GetSection("AppSettings").Get<StaticAppSettings>());
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDA0NDI0QDMxMzgyZTM0MmUzMEtnWldTUlR3TFFoMW5pNm1XVG9nMStvZU9lYnVEVVBjcGpHQ0luR3hSdG89");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
