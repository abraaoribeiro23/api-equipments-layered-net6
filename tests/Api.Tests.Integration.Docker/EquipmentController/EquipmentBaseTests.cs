using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

public class EquipmentBaseTests : IAsyncLifetime
{
    protected readonly Func<Task> ResetDatabaseAsync;
    protected readonly HttpClient Client;

    protected EquipmentBaseTests(CustomWebApplicationFactory factory)
    {
        Client = factory.HttpClient;
        ResetDatabaseAsync = factory.ResetDatabaseAsync;
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => ResetDatabaseAsync();
}