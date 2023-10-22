using Homewizard.Energy.Api.Client.Clients;

namespace Homewizard.Energy.Api.CliTool;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IWifiEnergySocketClient _client;
    private readonly TimeSpan delay = TimeSpan.FromSeconds(0.5);

    public Worker(ILogger<Worker> logger, IWifiEnergySocketClient client)
    {
        _logger = logger;
        _client = client;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new PeriodicTimer(delay);
        while (!stoppingToken.IsCancellationRequested)
        {
            await PrintData(stoppingToken);
            await timer.WaitForNextTickAsync(stoppingToken);
        }
    }

    private async Task PrintData(CancellationToken stoppingToken)
    {
        var data = await _client.GetSocketData(stoppingToken);
        _logger.LogInformation("Active Power: {ActivePower}", data.ActivePower);
        _logger.LogInformation("Total Power Import: {TotalPowerImportT1}", data.TotalPowerImportT1);
    }
}
