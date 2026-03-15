using MaskinPark.Shared.Constants;
using MaskinPark.Shared.Dtos;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace Maskinpark.Client.Services;

public class ClientApiService(HttpClient httpClient, ILogger<ClientApiService> logger) : IClientApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<ClientApiService> _logger = logger;
    private readonly JsonSerializerOptions _jsonOptions = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public async Task<IReadOnlyCollection<MachineDto>?> GetAllMachinesAsync(CancellationToken token = default)
    {
        HttpResponseMessage response;
        try {
            response = await _httpClient.GetAsync("/api/machines", token);
        } catch (InvalidOperationException ex) {
            _logger.LogError("InvalidOperationException: {ErrorMessage}", ex.Message);
            return [];
        }        
        response.EnsureSuccessStatusCode();
        return await JsonSerializer.DeserializeAsync<IReadOnlyCollection<MachineDto>>(await response.Content.ReadAsStreamAsync(token), _jsonOptions, token);
    }

    public async Task AddMachineAsync(MachineDto machine, CancellationToken token = default)
    {
        StringContent content = new(JsonSerializer.Serialize(machine, _jsonOptions), encoding: Encoding.UTF8, "application/json");
        HttpResponseMessage response;
        try {
            response = await _httpClient.PostAsync("/api/machines/create", content, token);
        } catch (InvalidOperationException ex) {
            _logger.LogError("InvalidOperationException: {ErrorMessage}", ex.Message);
            return;
        }
        if (response.StatusCode != HttpStatusCode.Created) {
            throw new Exception("something bad happened");
        }
    }
}
