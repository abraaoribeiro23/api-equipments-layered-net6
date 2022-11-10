using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bogus;
using Services.Contracts.Equipment;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

public class CreateEquipmentControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private const string RequestUrl = "/api/v1/equipment/create";
    private const string ExistentModel = "a3540227-2f0e-4362-9517-92f41dabbfdf";

    private readonly HttpClient _client;

    private readonly Faker<EquipmentCreateDto> _equipmentGenerator = new Faker<EquipmentCreateDto>()
        .RuleFor(dto => dto.Name, faker => faker.Lorem.Word())
        .RuleFor(dto => dto.EquipmentModelId, Guid.Parse(ExistentModel));

    public CreateEquipmentControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateEquipmentReturnsList()
    {
        // Arrange
        var createEquipmentDto = _equipmentGenerator.Generate();

        // Act
        var createResponse = await _client.PostAsJsonAsync(RequestUrl, createEquipmentDto);

        // Assert
        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        Assert.NotNull(createResponse.Content);
        var result = await createResponse.Content.ReadFromJsonAsync<EquipmentDto>();
        Assert.NotNull(result);
    }
}
