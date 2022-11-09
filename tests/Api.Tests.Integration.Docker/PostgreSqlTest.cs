using System.Data;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Npgsql;
using Xunit;

namespace Api.Tests.Integration.Docker;
public sealed class PostgreSqlTest : IAsyncLifetime
{
    private readonly TestcontainerDatabase _testcontainers = new TestcontainersBuilder<PostgreSqlTestcontainer>()
        .WithDatabase(new PostgreSqlTestcontainerConfiguration
        {
            Database = "db",
            Username = "postgres",
            Password = "postgres",
        })
        .Build();

    [Fact]
    public void ExecuteCommand()
    {
        using var connection = new NpgsqlConnection(_testcontainers.ConnectionString);
        using (var command = new NpgsqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT 1";
            command.ExecuteNonQuery();
        }
        Assert.Equal(ConnectionState.Closed,connection.State);
    }

    public Task InitializeAsync()
    {
        return _testcontainers.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _testcontainers.DisposeAsync().AsTask();
    }
}