﻿using System.Reflection;
using Aiko.Domain.Models;
using Aiko.Infra.Repositories;
using Aiko.UnitTests.DataInjectors;
using Xunit;
using Xunit.Priority;

namespace Aiko.IntegrationTests.EquipmentPositionHistoryTests;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EquipmentPositionHistoryContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentPositionHistoryContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentPositionHistoryContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "First context Test")]
    [Priority(1)]
    public void GetAll_EquipmentPositionHistory_InitialContext()
    {
        InjectDataOnContext.InitializeDbForTests(_fixture.SqlContextFixture);
        var repopository = new EquipmentPositionHistoryRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);

        var equipmentModels = result.ToList();
        Assert.NotEmpty(equipmentModels);
        Assert.Equal(722, equipmentModels.Count);
    }

    [Fact(DisplayName = "Secound context Test")]
    [Priority(2)]
    public void GetAll_EquipmentPositionHistory_AddInContext()
    {
        var equipmentModelJson =
            Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_position_history_001.json");
        InjectDataOnContext.AddInContext<EquipmentPositionHistory>(_fixture.SqlContextFixture,
            equipmentModelJson);

        var repopository = new EquipmentPositionHistoryRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var equipmentModels = result.ToList();
        Assert.NotEmpty(equipmentModels);
        Assert.Equal(723, equipmentModels.Count);
    }
}