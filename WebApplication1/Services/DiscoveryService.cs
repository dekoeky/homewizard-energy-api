using System.Collections.Concurrent;
using Makaretu.Dns;
using Timer = System.Timers.Timer;

namespace WebApplication1.Services;

public class HomewizardDiscoveryService : IHostedService, IDisposable
{
    private const string DomainPartOne = "_hwenergy";
    private const string DomainPartTwo = "_tcp";

    private static readonly TimeSpan Delay = TimeSpan.FromSeconds(60);
    private readonly ILogger<HomewizardDiscoveryService> _logger;
    private readonly Timer _timer = new(Delay);
    private readonly ServiceDiscovery _discovery = new();
    private static readonly DomainName Service = new(DomainPartOne, DomainPartTwo);
    private readonly ConcurrentBag<string> _discovered = new();

    public HomewizardDiscoveryService(ILogger<HomewizardDiscoveryService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _discovery.ServiceInstanceDiscovered += _discovery_ServiceInstanceDiscovered;
        _timer.Elapsed += Timer_Elapsed;

        _timer.Start();

        return Task.CompletedTask;
    }

    private void _discovery_ServiceInstanceDiscovered(object? sender, ServiceInstanceDiscoveryEventArgs e)
    {
        _logger.LogDebug("Service Instance Discovered: {ServiceInstanceName}", e.ServiceInstanceName);
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
        _logger.LogInformation("⚡ Discovered {hostname}", hostname);
    }

    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) => _discovery.QueryServiceInstances(Service);

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Stop();

        _timer.Elapsed -= Timer_Elapsed;
        _discovery.ServiceInstanceDiscovered -= _discovery_ServiceInstanceDiscovered;

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
        _discovery.Dispose();
    }
}
