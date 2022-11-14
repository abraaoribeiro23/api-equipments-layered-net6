using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bogus;
using Services.Contracts.Equipment;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

[Collection(nameof(SharedTestCollection))]
public class EditEquipmentControllerTests : EquipmentBaseTests
{
    private const string CreateRequestUrl = "/api/v1/equipment/create";
    private const string EditRequestUrl = "/api/v1/equipment/edit";
    private const string ExistentModel = "a3540227-2f0e-4362-9517-92f41dabbfdf";

    private readonly Faker<EquipmentCreateDto> _equipmentCreateDtoGenerator = new Faker<EquipmentCreateDto>()
        .RuleFor(dto => dto.Name, faker => faker.Lorem.Word())
        .RuleFor(dto => dto.EquipmentModelId, Guid.Parse(ExistentModel));

    private readonly Faker<EquipmentUpdateDto> _equipmentUpdateDtoGenerator = new Faker<EquipmentUpdateDto>()
        .RuleFor(dto => dto.Name, faker => faker.Lorem.Word())
        .RuleFor(dto => dto.EquipmentModelId, Guid.Parse(ExistentModel));

    public EditEquipmentControllerTests(CustomWebApplicationFactory factory) : base(factory)
    {
    }

    //[Fact]
    public async Task Edit_Equipment_Success()
    {
        // Arrange
        var createEquipmentDto = _equipmentCreateDtoGenerator.Generate();
        await Client.PostAsJsonAsync(CreateRequestUrl, createEquipmentDto);

        var updateEquipmentDto = _equipmentUpdateDtoGenerator.Generate();

        // Act
        var editResponse = await Client.PostAsJsonAsync(EditRequestUrl, updateEquipmentDto);

        // Assert
        Assert.Equal(HttpStatusCode.Accepted, editResponse.StatusCode);
    }
}
