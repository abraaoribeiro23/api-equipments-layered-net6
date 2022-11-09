using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Newtonsoft.Json;
using Services.Contracts.Equipment;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentsApi;

public class CreateEquipmentTest : IClassFixture<CustomWebApplicationFactory>
{
    private const string RequestUrl = "/api/v1/equipment/create";
    private readonly HttpClient _client;

    private readonly Faker<EquipmentCreateDto> _equipmentGenerator = new Faker<EquipmentCreateDto>()
        .RuleFor(dto => dto.Name, faker => faker.Lorem.Word())
        .RuleFor(dto => dto.EquipmentModelId, Guid.NewGuid);

    public CreateEquipmentTest(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetEquipmentReturnsList()
    {
        var createEquipmentDto = _equipmentGenerator.Generate();
        var serializedEquipment = JsonConvert.SerializeObject(createEquipmentDto);
        HttpContent httpContent = new StringContent(serializedEquipment, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var actualResponse = await _client.PostAsync(RequestUrl, httpContent).ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.Created, actualResponse.StatusCode);
    }
}
