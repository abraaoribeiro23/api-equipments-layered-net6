using System.Reflection;
using Api.Tests.Integration.DataInjectors;
using Domain.Models;
using Persistence.Repositories;
using Xunit;
using Xunit.Priority;

namespace Api.Tests.Integration.EquipmentStateTests;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EquipmentStateContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentStateContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentStateContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "First context Test")]
    [Priority(1)]
    public void GetAll_EquipmentState_InitialContext()
    {
        InjectDataOnContext.InitializeDbForTests(_fixture.SqlContextFixture);
        var repopository = new EquipmentStateRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);

        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(3, entities.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_EquipmentState_AddInContext()
    {
        var json = Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_state_001.json");
        InjectDataOnContext.AddInContext<EquipmentState>(_fixture.SqlContextFixture, json);

        var repopository = new EquipmentStateRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(4, entities.Count);
    }
}