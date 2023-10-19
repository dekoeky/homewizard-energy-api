using System.Collections.Concurrent;
using Makaretu.Dns;

namespace Homewizard.Energy.Api.Client;

public class DeviceDiscoverer : IDisposable
{
    public const string DomainPartOne = "_hwenergy";
    public const string DomainPartTwo = "_tcp";
    private static readonly DomainName Domain = new(DomainPartOne, DomainPartTwo);

    private readonly ServiceDiscovery _discovery = new();
    private readonly ConcurrentBag<string> _discovered = new();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
            return;

        _discovery.ServiceInstanceDiscovered -= ServiceInstanceDiscovered;
        _discovery.Dispose();
    }

    private void ServiceInstanceDiscovered(object? sender, ServiceInstanceDiscoveryEventArgs e)
    {
        var parent = e.ServiceInstanceName.Parent();

        if (parent is null) return;

        if (DomainPartOne.Equals(parent.Labels[0], StringComparison.InvariantCultureIgnoreCase))
            _discovered.Add(e.ServiceInstanceName.Labels[0]);
    }

    public async Task<string[]> Discover(TimeSpan timeout, CancellationToken token = default)
    {
        _discovery.ServiceInstanceDiscovered += ServiceInstanceDiscovered;
        _discovery.QueryServiceInstances(Domain);

        await Task.Delay(timeout, token);

        _discovery.ServiceInstanceDiscovered -= ServiceInstanceDiscovered;

        return _discovered.OrderBy(s => s).Distinct().ToArray();
    }
}
