using System.Reflection;
using Aiko.Domain.Models;
using Aiko.Infra.Repositories;
using Aiko.UnitTests.DataInjectors;
using Xunit;

namespace Aiko.IntegrationTests.EquipmentModelTests;

public class EquipmentModelContextTests : IClassFixture<ServiceProviderFixture>
{
    private static readonly Type ClassType = typeof(EquipmentModelContextTests);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    private readonly ServiceProviderFixture _fixture;

    public EquipmentModelContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        var equipmentModelJson =
            Assembly?.GetManifestResourceStream($"{JsonPath}.equipment_model_001.json");
        InjectDataOnContext.AddInContext<EquipmentModel>(fixture.SqlContextFixture, equipmentModelJson);
    }

    [Fact]
    public void EquipmentModelContext_Exist()
    {
        var repopository = new EquipmentModelRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var equipmentModels = result.ToList();
        Assert.NotEmpty(equipmentModels);
        Assert.Single(equipmentModels);
    }
}