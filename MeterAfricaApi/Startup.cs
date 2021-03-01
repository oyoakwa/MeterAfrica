using MeterAfricaClassLib.Services;
using MeterAfricaClassLib.Services.MeterAfricaServices;
using MeterAfricaClassLibrary.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeterAfricaApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();
        } 

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IGetDiscoService, GetDiscoService>();
            services.AddTransient<IBaseHttpClient, BaseHttpClient>();
            services.AddTransient<IResponseService,ResponseService>();
            services.AddTransient<IValidateMeterNumberService, ValidateMeterNumberService>();
            services.AddSingleton(Configuration.GetSection("AppSettings").Get<AppSettings>());
            services.AddSingleton(Configuration.GetSection("AppSettings").Get<StaticAppSettings>());
            services.AddHttpClient();

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
             {
                "text/plain",
                "text/css",
                "application/javascript",
                "text/html",
                "application/json",
                "text/json"
               };
                options.EnableForHttps = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
