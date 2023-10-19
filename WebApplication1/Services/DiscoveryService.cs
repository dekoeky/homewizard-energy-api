using System.Collections.Concurrent;
using Makaretu.Dns;

namespace WebApplication1.Controllers;

public class DiscoveryService : BackgroundService
{
    private const string DomainPartOne = "_hwenergy";
    private const string DomainPartTwo = "_tcp";
    private static readonly DomainName Service = new(DomainPartOne, DomainPartTwo, "_local");
    private readonly TimeSpan delay = TimeSpan.FromMinutes(1);
    private readonly ILogger<DiscoveryService> _logger;

    private readonly ServiceDiscovery _discovery = new();
    private ConcurrentBag<string> _discovered = new();

    public DiscoveryService(ILogger<DiscoveryService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _discovery.ServiceInstanceDiscovered += _discovery_ServiceInstanceDiscovered;

        while (!stoppingToken.IsCancellationRequested)
        {
            _discovery.QueryServiceInstances(Service);
            await Task.Delay(delay, stoppingToken);
        }

        _discovery.ServiceInstanceDiscovered -= _discovery_ServiceInstanceDiscovered;
    }

    private void _discovery_ServiceInstanceDiscovered(object? sender, ServiceInstanceDiscoveryEventArgs e)
    {
        var parent = e.ServiceInstanceName.Parent();

        if (DomainPartOne.Equals(parent.Labels.ElementAtOrDefault(0), StringComparison.InvariantCultureIgnoreCase))
            Discovered(e.ServiceInstanceName.Labels.First());
    }

    private void Discovered(string hostname)
    {
        lock (_discovered)
        {
            if (_discovered.Contains(hostname)) return;

            _discovered.Add(hostname);
        }
        _logger.LogInformation("Discovered {hostname}", hostname);
    }
}
