using System.Net.Http.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Clients;

public class WifiEnergySocketClient : BaseClient, IWifiEnergySocketClient
{

    public WifiEnergySocketClient(HttpClient client) : base(client) { }
    public WifiEnergySocketClient(Uri uri) : base(new HttpClient { BaseAddress = uri }) { }
    public WifiEnergySocketClient(string uri) : base(new Uri(uri)) { }

    public Task<EnergySocketStateData?> GetState(CancellationToken cancellationToken = default)
        => _http.GetFromJsonAsync<EnergySocketStateData>(Endpoints.State, cancellationToken);

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
}
