using System.Net.Http.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Clients;

public class WifiEnergySocketClient : BasicClient, IWifiEnergySocketClient
{
    public WifiEnergySocketClient(HttpClient client) : base(client) { }
    public WifiEnergySocketClient(Uri uri) : base(new HttpClient { BaseAddress = uri }) { }
    public WifiEnergySocketClient(string uri) : base(new Uri(uri)) { }

    public Task<EnergySocketStateData?> GetState(CancellationToken cancellationToken = default)
        => Http.GetFromJsonAsync<EnergySocketStateData>(Endpoints.State, cancellationToken);

    /// <summary>
    /// Can be used to let the user identify the device. The status light will blink for a few seconds after calling this endpoint.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IdentifyData?> Identify(CancellationToken cancellationToken = default)
    {
        var response = await Http.PutAsync(Endpoints.Identify, null, cancellationToken);

        var data = await response.Content.ReadFromJsonAsync<IdentifyData>(cancellationToken: cancellationToken);

        return data;
    }

    public Task<HweSktData?> GetSocketData(CancellationToken cancellationToken = default)
        => Http.GetFromJsonAsync<HweSktData>(Endpoints.Data, cancellationToken);
    public Task<SystemSettings?> GetSystem(CancellationToken cancellationToken = default)
        => Http.GetFromJsonAsync<SystemSettings>(Endpoints.System, cancellationToken);

    public async Task<EnergySocketStateData?> SetState(EnergySocketStateData wantedState, CancellationToken cancellationToken = default)
    {
        var response = await Http.PutAsJsonAsync(Endpoints.State, wantedState, cancellationToken);

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
