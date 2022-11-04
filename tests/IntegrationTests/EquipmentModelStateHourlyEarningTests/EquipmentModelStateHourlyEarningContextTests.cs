using System.Reflection;
using Api.Tests.Integration.DataInjectors;
using Domain.Models;
using Persistence.Repositories;
using Xunit;
using Xunit.Priority;

namespace Api.Tests.Integration.EquipmentModelStateHourlyEarningTests;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EquipmentModelStateHourlyEarningContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentModelStateHourlyEarningContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentModelStateHourlyEarningContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "First context Test")]
    [Priority(1)]
    public void GetAll_EquipmentModelStateHourlyEarning_InitialContext()
    {
        InjectDataOnContext.InitializeDbForTests(_fixture.SqlContextFixture);
        var repopository = new EquipmentModelStateHourlyEarningRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);

        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(9, entities.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_EquipmentModelStateHourlyEarning_AddInContext()
    {
        var json = Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_model_state_hourly_earnings_001.json");
        InjectDataOnContext.AddInContext<EquipmentModelStateHourlyEarning>(_fixture.SqlContextFixture, json);

        var repopository = new EquipmentModelStateHourlyEarningRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var entities = result.ToList();
        Assert.NotEmpty(entities);
        Assert.Equal(10, entities.Count);
    }
}