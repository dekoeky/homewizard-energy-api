using Homewizard.Energy.Api.Client.Models;
using System.Net.Http.Json;

namespace Homewizard.Energy.Api.Client.Clients;

public class Client : IClient, IWifiEnergySocketClient
{
    private readonly HttpClient _http;

    public Client(HttpClient client)
    {
        _http = client;
    }
    public Client(Uri uri) : this(new HttpClient { BaseAddress = uri }) { }
    public Client(string uri) : this(new Uri(uri)) { }
    public Task<BasicInformation?> GetBasicInformation(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<BasicInformation>(Endpoints.BasicInformation, cancellationToken);

    /// <summary>
    /// Can be used to let the user identify the device. The status light will blink for a few seconds after calling this endpoint.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IdentifyData?> Identify(CancellationToken cancellationToken = default)
    {
        var response = await _http.PutAsync(Endpoints.Identify, null, cancellationToken);

        var data = await response.Content.ReadFromJsonAsync<IdentifyData>(cancellationToken: cancellationToken);

        return data;
    }

    public Task<SystemSettings?> GetSystem(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<SystemSettings>(Endpoints.System, cancellationToken);
    public Task<HweSktData?> GetSocketData(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<HweSktData>(Endpoints.Data, cancellationToken);

    public Task<EnergySocketStateData?> GetState(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<EnergySocketStateData>(Endpoints.State, cancellationToken);
    public async Task<EnergySocketStateData?> SetState(EnergySocketStateData wantedState, CancellationToken cancellationToken = default)
    {
        var response = await _http.PutAsJsonAsync(Endpoints.State, wantedState, cancellationToken);

        var data = await response.Content.ReadFromJsonAsync<EnergySocketStateData>();

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