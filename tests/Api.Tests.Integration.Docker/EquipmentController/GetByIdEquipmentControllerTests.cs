﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Services.Contracts.Equipment;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

[Collection(nameof(SharedTestCollection))]
public class GetByIdEquipmentControllerTests : EquipmentBaseTests
{
    private const string RequestUrl = "/api/v1/equipment/get-by-id";
    private const string ExistentEquipment = "a7c53eb1-4f5e-4eba-9764-ad205d0891f9";
    
    public GetByIdEquipmentControllerTests(CustomWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAllEquipmentReturnsList()
    {
        // Arrange
        var equipmentGuid = "/" + ExistentEquipment;
        // Act
        var response = await Client.GetAsync(RequestUrl + equipmentGuid);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response.Content);

        var result = await response.Content
            .ReadFromJsonAsync<EquipmentDto>();

        Assert.NotNull(result);
    }
}
