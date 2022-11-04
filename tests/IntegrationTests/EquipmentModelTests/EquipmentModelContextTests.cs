using System.Reflection;
using Api.Tests.Integration.DataInjectors;
using Domain.Models;
using Persistence.Repositories;
using Xunit;
using Xunit.Priority;

namespace Api.Tests.Integration.EquipmentModelTests;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EquipmentModelContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentModelContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentModelContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "First context Test")]
    [Priority(1)]
    public void GetAll_EquipmentModel_InitialContext()
    {
        InjectDataOnContext.InitializeDbForTests(_fixture.SqlContextFixture);
        var repopository = new EquipmentModelRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);

        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(3, entities.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_EquipmentModel_AddInContext()
    {
        var json = Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_model_001.json");
        InjectDataOnContext.AddInContext<EquipmentModel>(_fixture.SqlContextFixture, json);

        var repopository = new EquipmentModelRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(4, entities.Count);
    }
}