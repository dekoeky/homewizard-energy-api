using System.Net.Http.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Clients;

public class BaseClient : IBaseClient
{
    protected readonly HttpClient _http;

    public BaseClient(HttpClient client)
    {
        _http = client;
    }
    public BaseClient(Uri uri) : this(new HttpClient { BaseAddress = uri }) { }
    public BaseClient(string uri) : this(new Uri(uri)) { }
    public Task<BasicInformation?> GetBasicInformation(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<BasicInformation>(Endpoints.BasicInformation, cancellationToken);


    public Task<SystemSettings?> GetSystem(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<SystemSettings>(Endpoints.System, cancellationToken);
    public Task<HweSktData?> GetSocketData(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<HweSktData>(Endpoints.Data, cancellationToken);

    public async Task<EnergySocketStateData?> SetState(EnergySocketStateData wantedState, CancellationToken cancellationToken = default)
    {
        var response = await _http.PutAsJsonAsync(Endpoints.State, wantedState, cancellationToken);

        var data = await response.Content.ReadFromJsonAsync<EnergySocketStateData>(cancellationToken: cancellationToken);

        return data;
    }

    public Task<SystemSettings?> SetSystemSettings(SystemSettings settings, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<SystemSettings?> GetSystemSettings(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
