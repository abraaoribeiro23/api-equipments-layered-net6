using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Persistence.Context;
using Xunit;

namespace Api.Tests.Integration.Docker.EquipmentsApi;

public class EquipmentsComponentTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public EquipmentsComponentTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetEquipmentReturnsList()
    {
        var actualResponse = await _client
            .GetAsync("/api/v1/equipment/get-all")
            .ConfigureAwait(false);
        var actualResponseString = await actualResponse.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);

        using StringReader stringReader = new(actualResponseString);
        using JsonTextReader reader = new(stringReader)
            { DateParseHandling = DateParseHandling.None };
        var jsonResponse = await JObject.LoadAsync(reader)
            .ConfigureAwait(false);

        Assert.Equal(JTokenType.String, jsonResponse["data"]![0]!["model"]!.Type);
        Assert.Equal(JTokenType.Integer, jsonResponse["data"]![0]!["passengerQuantity"]!.Type);

        Assert.True(int.TryParse(
            jsonResponse["data"]![0]!["passengerQuantity"]!.Value<string>(),
            out var _));
    }
}
