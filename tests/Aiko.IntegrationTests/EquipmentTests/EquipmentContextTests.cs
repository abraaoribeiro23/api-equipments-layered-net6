using System.Reflection;
using Aiko.Domain.Models;
using Aiko.Infra.Repositories;
using Aiko.UnitTests.DataInjectors;
using Xunit;
using Xunit.Priority;

namespace Aiko.IntegrationTests.EquipmentTests;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EquipmentContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "First context Test")]
    [Priority(1)]
    public void GetAll_Equipment_InitialContext()
    {
        InjectDataOnContext.InitializeDbForTests(_fixture.SqlContextFixture);
        var repopository = new EquipmentRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);

        var equipments = result.ToList();
        Assert.NotEmpty(equipments);
        Assert.Equal(9, equipments.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_Equipment_AddInContext()
    {
        var equipmentJson =
            Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_001.json");
        InjectDataOnContext.AddInContext<Equipment>(_fixture.SqlContextFixture, equipmentJson);

        var repopository = new EquipmentRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var equipments = result.ToList();
        Assert.NotEmpty(equipments);
        Assert.Equal(10, equipments.Count);
    }
}