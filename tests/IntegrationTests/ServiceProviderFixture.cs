using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Api.Tests.Integration;

public sealed class ServiceProviderFixture : IDisposable
{
    public ServiceProviderFixture()
    {
        var service = GetServiceCollection.Execute();
        var dbName = $"test_db_{Guid.NewGuid()}";
        service.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(dbName).EnableSensitiveDataLogging()
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
        var sp = service.BuildServiceProvider();
        Sp = sp;
        SqlContextFixture = sp.GetService<AppDbContext>()!;
    }

    public AppDbContext SqlContextFixture { get; set; }

    public ServiceProvider Sp { get; }

    public void Dispose()
    {
        SqlContextFixture.Database.EnsureDeleted();
    }
}