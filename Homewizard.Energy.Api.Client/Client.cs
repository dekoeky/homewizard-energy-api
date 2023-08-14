using Homewizard.Energy.Api.Client.Models;
using System.Net.Http.Json;

namespace Homewizard.Energy.Api.Client;

public class Client : IClient
{
    private readonly HttpClient client;

    public Client(HttpClient client, Uri baseUri)
    {
        this.client = client;
        this.client.BaseAddress = baseUri;
    }

    public Task<BasicInformation?> GetBasicInformation(CancellationToken cancellationToken = default)
        => client.GetFromJsonAsync<BasicInformation>("api", cancellationToken);
    public Task<IdentifyData?> GetIdentify(CancellationToken cancellationToken = default)
        => client.GetFromJsonAsync<IdentifyData>("api/v1/identify", cancellationToken);
    public Task<SystemStateData?> GetSystem(CancellationToken cancellationToken = default)
        => client.GetFromJsonAsync<SystemStateData>("api/v1/system", cancellationToken);
    public Task<HweSktData?> GetDataFromSocket(CancellationToken cancellationToken = default)
        => client.GetFromJsonAsync<HweSktData>("api/v1/system", cancellationToken);

}