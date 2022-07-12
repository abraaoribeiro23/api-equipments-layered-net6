using System.Reflection;
using Aiko.Domain.Models;
using Aiko.Infra.Repositories;
using Aiko.UnitTests.DataInjectors;
using Xunit;
using Xunit.Priority;

namespace Aiko.IntegrationTests.EquipmentStateHistoryTests;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EquipmentStateHistoryContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentStateHistoryContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentStateHistoryContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "First context Test")]
    [Priority(1)]
    public void GetAll_EquipmentStateHistory_InitialContext()
    {
        InjectDataOnContext.InitializeDbForTests(_fixture.SqlContextFixture);
        var repopository = new EquipmentStateHistoryRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);

        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(1064, entities.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_EquipmentStateHistory_AddInContext()
    {
        var json = Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_state_history_001.json");
        InjectDataOnContext.AddInContext<EquipmentStateHistory>(_fixture.SqlContextFixture, json);

        var repopository = new EquipmentStateHistoryRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(1065, entities.Count);
    }
}