using System.Net.Http.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Clients;

public class BasicClient : IBasicClient
{
    protected readonly HttpClient Http;

    public BasicClient(HttpClient client) { Http = client; }
    public BasicClient(Uri uri) : this(new HttpClient { BaseAddress = uri }) { }
    public BasicClient(string uri) : this(new Uri(uri)) { }

    public Task<BasicInformation?> GetBasicInformation(CancellationToken cancellationToken = default)
        => Http.GetFromJsonAsync<BasicInformation>(Endpoints.BasicInformation, cancellationToken);
}
