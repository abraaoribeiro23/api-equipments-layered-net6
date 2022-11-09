using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Persistence.Context;
using Xunit;

namespace Api.Tests.Integration.Docker;

/// <summary>
/// </summary>
public sealed class CustomWebApplicationFactory : WebApplicationFactory<Startup>, IAsyncLifetime
{
    private readonly TestcontainerDatabase _dbContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
        .WithDatabase(new PostgreSqlTestcontainerConfiguration
        {
            Database = "mydb",
            Username = "user",
            Password = "qwe123"
        }).Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(
            (context, config) =>
            {
                config.AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["FeatureManagement:Swagger"] = "false",
                        ["FeatureManagement:MsSqlServer"] = "false",
                        ["FeatureManagement:PostgresSql"] = "false",
                        ["FeatureManagement:InjectInitialData"] = "false"
                    });
            });

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(AppDbContext));
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(new NpgsqlConnection(_dbContainer.ConnectionString)));
        });
    }
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }
    public async Task DisposeAsync() => await _dbContainer.StopAsync();
}