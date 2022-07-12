﻿using System.Reflection;
using Aiko.Domain.Models;
using Aiko.Infra.Repositories;
using Aiko.UnitTests.DataInjectors;
using Xunit;
using Xunit.Priority;

namespace Aiko.IntegrationTests.EquipmentModelStateHourlyEarningTests;

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

        var equipmentModels = result.ToList();
        Assert.NotEmpty(equipmentModels);
        Assert.Equal(9, equipmentModels.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_EquipmentModelStateHourlyEarning_AddInContext()
    {
        var equipmentModelJson =
            Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_model_state_hourly_earnings_001.json");
        InjectDataOnContext.AddInContext<EquipmentModelStateHourlyEarning>(_fixture.SqlContextFixture,
            equipmentModelJson);

        var repopository = new EquipmentModelStateHourlyEarningRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var equipmentModels = result.ToList();
        Assert.NotEmpty(equipmentModels);
        Assert.Equal(10, equipmentModels.Count);
    }
}