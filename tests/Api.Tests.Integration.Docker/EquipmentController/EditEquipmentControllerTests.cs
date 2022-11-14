using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bogus;
using Persistence.Context;
using Services.Contracts.Equipment;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentController;

public class EditEquipmentControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private const string RequestUrl = "/api/v1/equipment/edit";

    private readonly HttpClient _client;
    private readonly AppDbContext _context;

    private readonly Faker<EquipmentUpdateDto> _equipmentGenerator = new Faker<EquipmentUpdateDto>()
        .RuleFor(dto => dto.Name, faker => faker.Lorem.Word());

    public EditEquipmentControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    //[Fact]
    public async Task Edit_Equipment_Success()
    {
        // Arrange
        var equipment = _context.Equipments.FirstOrDefault();
        var updateEquipmentDto = _equipmentGenerator.Clone()
            .RuleFor(dto => dto.Id, equipment?.Id)
            .RuleFor(dto => dto.EquipmentModelId, equipment?.EquipmentModelId)
            .Generate();

        // Act
        var editResponse = await _client.PostAsJsonAsync(RequestUrl, updateEquipmentDto);

        // Assert
        Assert.Equal(HttpStatusCode.Accepted, editResponse.StatusCode);
        var editedEquipment = _context.Equipments.FirstOrDefault(e => e.Id == updateEquipmentDto.Id);
        Assert.NotNull(editedEquipment);
        Assert.Equal(updateEquipmentDto.Name,editedEquipment?.Name);
    }
}
