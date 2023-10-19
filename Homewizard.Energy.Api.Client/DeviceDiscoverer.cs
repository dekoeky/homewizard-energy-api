using System.Collections.Concurrent;
using Makaretu.Dns;

namespace Homewizard.Energy.Api.Client;


public class DeviceDiscoverer : IDisposable
{
    public const string DomainPartOne = "_hwenergy";
    public const string DomainPartTwo = "_tcp";
    private static readonly DomainName domain = new(DomainPartOne, DomainPartTwo);

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

        if (DomainPartOne.Equals(parent.Labels.ElementAtOrDefault(0), StringComparison.InvariantCultureIgnoreCase))
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
