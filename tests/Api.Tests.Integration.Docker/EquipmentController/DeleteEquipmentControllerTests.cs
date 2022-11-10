using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

public class DeleteEquipmentControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private const string RequestUrl = "/api/v1/equipment/delete";
    private const string ExistentEquipment = "a7c53eb1-4f5e-4eba-9764-ad205d0891f9";

    private readonly HttpClient _client;

    public DeleteEquipmentControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Delete_Equipment_Success()
    {
        // Arrange
        var equipmentGuid = "/" + ExistentEquipment;
        // Act
        var response = await _client.DeleteAsync(RequestUrl + equipmentGuid);
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Delete_Equipment_NotFound()
    {
        // Arrange
        var equipmentGuid = "/" + Guid.NewGuid();
        // Act
        var response = await _client.DeleteAsync(RequestUrl + equipmentGuid);
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
