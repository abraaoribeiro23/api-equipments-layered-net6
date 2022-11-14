using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Services.Contracts.Equipment;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

[Collection(nameof(SharedTestCollection))]
public class GetAllEquipmentControllerTests : EquipmentBaseTests
{
    private const string RequestUrl = "/api/v1/equipment/get-all";

    public GetAllEquipmentControllerTests(CustomWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAllEquipmentReturnsList()
    {
        // Act
        var getAllResponse = await Client.GetAsync(RequestUrl);

        // Assert
        Assert.Equal(HttpStatusCode.OK, getAllResponse.StatusCode);
        Assert.NotNull(getAllResponse.Content);

        var result = await getAllResponse.Content
            .ReadFromJsonAsync<IEnumerable<EquipmentDto>>();

        Assert.NotNull(result);
        Assert.Equal(9, result?.Count());
    }
}
