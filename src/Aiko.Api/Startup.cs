using Aiko.Api.Modules.Common;
using Aiko.Api.Modules.Common.Swagger;
using Aiko.Application.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.FeatureManagement;
using Serilog;

namespace Aiko.Api
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

            Initializer.Configure(services);

            services
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
