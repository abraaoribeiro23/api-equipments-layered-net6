using Aiko.Infra.Repositories;
using Aiko.UnitTests.DataInjectors;
using Xunit;

namespace Aiko.IntegrationTests.EquipmentModelTests;

public class EquipmentModelContext2Tests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public EquipmentModelContext2Tests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContext.InitializeDbForTests(fixture.SqlContextFixture);
    }

    [Fact]
    public void EquipmentModelContext_Exist()
    {
        var repopository = new EquipmentModelRepository(_fixture.SqlContextFixture);
        var result = repopository.GetAll();
        Assert.NotNull(result);
        var equipmentModels = result.ToList();
        Assert.NotEmpty(equipmentModels);
        Assert.Equal(3, equipmentModels.Count);
    }
}