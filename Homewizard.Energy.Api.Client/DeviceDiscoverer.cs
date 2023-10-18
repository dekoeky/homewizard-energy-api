using Makaretu.Dns;
using System.Collections.Concurrent;

namespace Homewizard.Energy.Api.Client;

public class DeviceDiscoverer : IDisposable
{
    private const string domainPartOne = "_hwenergy";
    private const string domainPartTwo = "_tcp";
    private static readonly DomainName domain = new(domainPartOne, domainPartTwo);

    private readonly ServiceDiscovery sd = new();
    private ConcurrentBag<string> discovered = new();


    public void Dispose()
    {
        sd.ServiceInstanceDiscovered -= ServiceInstanceDiscovered;
        sd?.Dispose();
    }

    private void ServiceInstanceDiscovered(object? sender, ServiceInstanceDiscoveryEventArgs e)
    {
        var parent = e.ServiceInstanceName.Parent();

        if (domainPartOne.Equals(parent.Labels.ElementAtOrDefault(0), StringComparison.InvariantCultureIgnoreCase))
            discovered.Add(e.ServiceInstanceName.Labels.First());
    }

    public async Task<string[]> Discover(TimeSpan timeout, CancellationToken token = default)
    {
        sd.ServiceInstanceDiscovered += ServiceInstanceDiscovered;
        sd.QueryServiceInstances(domain);

        await Task.Delay(timeout, token);

        sd.ServiceInstanceDiscovered -= ServiceInstanceDiscovered;

        return discovered.OrderBy(s => s).Distinct().ToArray();
    }
}