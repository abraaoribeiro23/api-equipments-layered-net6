using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

[Collection(nameof(SharedTestCollection))]
public class DeleteEquipmentControllerTests : EquipmentBaseTests
{
    private const string RequestUrl = "/api/v1/equipment/delete";
    private const string ExistentEquipment = "a7c53eb1-4f5e-4eba-9764-ad205d0891f9";

    public DeleteEquipmentControllerTests(CustomWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Delete_Equipment_Success()
    {
        // Arrange
        var equipmentGuid = "/" + ExistentEquipment;
        // Act
        var response = await Client.DeleteAsync(RequestUrl + equipmentGuid);
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
