﻿using Api.Modules.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace Api.Tests.Integration;

public class GetServiceCollection
{
    public static ServiceCollection Execute()
    {
        var services = new ServiceCollection();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .Build();

        services.AddFeatureManagement(configuration);

        services
            .AddDbContext(configuration)
            .AddEntityRepository()
            .AddServices()
            .AddAutoMapperSetup()
            .AddEndpointsApiExplorer()
            .AddVersioning()
            .AddSwaggerGen()
            .AddCustomControllers();

        return services;
    }
}