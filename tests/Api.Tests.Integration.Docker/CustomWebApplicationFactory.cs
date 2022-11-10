using System.Collections.Generic;
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
using Persistence.Context;
using Xunit;

namespace Api.Tests.Integration.Docker;

public class CustomWebApplicationFactory : WebApplicationFactory<Startup>, IAsyncLifetime
{
    private readonly TestcontainerDatabase _dbContainer;
    public CustomWebApplicationFactory()
    {
        _dbContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = "mydb",
                Username = "user",
                Password = "qwe123"
            })
            .WithCleanUp(true)
            .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(
            (context, config) =>
            {
                config.AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["FeatureManagement:MsSqlServer"] = "false",
                        ["FeatureManagement:PostgresSql"] = "false",
                        ["FeatureManagement:InMemoryDatabase"] = "false"
                    });
            });

        builder.ConfigureTestServices(services =>
        {
            // Remove AppDbContext
            services.RemoveDbContext<AppDbContext>();
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(_dbContainer.ConnectionString));

            // Ensure schema gets created
            services.EnsureDbCreated<AppDbContext>();
        });
    }
    public async Task InitializeAsync() => await _dbContainer.StartAsync();

    public new async Task DisposeAsync() => await _dbContainer.DisposeAsync();
}