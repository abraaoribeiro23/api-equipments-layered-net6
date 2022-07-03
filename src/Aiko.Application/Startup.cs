using Aiko.Application.Modules.Common;
using Aiko.Application.Modules.Common.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.FeatureManagement;
using Serilog;

namespace Aiko.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFeatureManagement(Configuration);

            services
                .AddDbContext(Configuration)
                .AddEntityRepository()
                .AddServices()
                .AddEndpointsApiExplorer()
                .AddVersioning()
                .AddSwaggerGen()
                .AddCustomControllers();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/V1/CustomError")
                    .UseHsts();
            }

            app
                .UseRouting()
                .UseVersionedSwagger(provider, Configuration)
                .UseSerilogRequestLogging()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
