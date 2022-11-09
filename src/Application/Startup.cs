using Api.Modules.Common;
using Api.Modules.Common.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using Persistence.Context;
using Serilog;

namespace Api;
public sealed class Startup
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
            .AddAutoMapperSetup()
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
