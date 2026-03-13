using MaskinPark.Shared.Constants;
using MaskinPark.Shared.Dtos;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Maskinpark.Client.Services;

public class ClientApiService(HttpClient httpClient) : IClientApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public async Task<IReadOnlyCollection<MachineDto>?> GetAllMachinesAsync(CancellationToken token = default)
    {
        var response = await _httpClient.GetAsync("api/machines", token);
        response.EnsureSuccessStatusCode();
        return await JsonSerializer.DeserializeAsync<IReadOnlyCollection<MachineDto>>(await response.Content.ReadAsStreamAsync(token), _jsonOptions, token);
    }

    public async Task AddMachineAsync(MachineDto machine, CancellationToken token = default)
    {
        StringContent content = new(JsonSerializer.Serialize(machine, _jsonOptions), encoding: Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/api/machines/create", content, token);
        if (response.StatusCode != HttpStatusCode.Created) {
            throw new Exception("something bad happened");
        }
    }
}
