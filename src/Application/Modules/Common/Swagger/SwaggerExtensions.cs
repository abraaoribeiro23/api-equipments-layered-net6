using System.Reflection;
using Api.Modules.Common.FeatureFlags;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Modules.Common.Swagger;

/// <summary>
///     Swagger Extensions.
/// </summary>
public static class SwaggerExtensions
{
    private static string XmlCommentsFilePath
    {
        get
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }


    /// <summary>
    ///     Add Swagger Configuration dependencies.
    /// </summary>
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        var featureManager = services
            .BuildServiceProvider()
            .GetRequiredService<IFeatureManager>();

        var isEnabled = featureManager
            .IsEnabledAsync(nameof(CustomFeature.Swagger))
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();

        if (isEnabled)
        {
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddSwaggerGen(
                    c =>
                    {
                        c.IncludeXmlComments(XmlCommentsFilePath);
                        c.AddSecurityDefinition("Bearer",
                            new OpenApiSecurityScheme
                            {
                                In = ParameterLocation.Header,
                                Description = "Please insert JWT with Bearer into field",
                                Name = "Authorization",
                                Type = SecuritySchemeType.ApiKey
                            });
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                    }
                                },
                                new List<string>()
                            }
                        });
                    });
        }

        return services;
    }

    /// <summary>
    ///     Add Swagger dependencies.
    /// </summary>
    public static IApplicationBuilder UseVersionedSwagger(
        this IApplicationBuilder app,
        IApiVersionDescriptionProvider provider,
        IConfiguration configuration)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    string swaggerEndpoint;

                    var basePath = configuration["ASPNETCORE_BASEPATH"];

                    if (!string.IsNullOrEmpty(basePath))
                    {
                        swaggerEndpoint =
                            $"{basePath}/swagger/{description.GroupName}/swagger.json";
                    }
                    else
                    {
                        swaggerEndpoint = $"/swagger/{description.GroupName}/swagger.json";
                    }

                    options.SwaggerEndpoint(swaggerEndpoint,
                        description.GroupName.ToUpperInvariant());
                }
            });

        return app;
    }
}