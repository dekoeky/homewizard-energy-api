using Elastic.Clients.Elasticsearch;
using ElasticInserterDemo.Models;
using Homewizard.Energy.Api.Client.Clients;

namespace ElasticInserterDemo.Services;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IWifiEnergySocketClient socketClient;
    private readonly ElasticsearchClient elasticSearch;

    public Worker(ILogger<Worker> logger, IWifiEnergySocketClient socketClient, ElasticsearchClient elasticSearch)
    {
        _logger = logger;
        this.socketClient = socketClient;
        this.elasticSearch = elasticSearch;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        uint counter = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            var data = new Data
            {
                Counter = ++counter,
                BasicInformation = await socketClient.GetBasicInformation(stoppingToken),
                SocketData = await socketClient.GetSocketData(stoppingToken),
            };

            var result = await elasticSearch.IndexAsync(data, stoppingToken);

            if (result.IsSuccess())
            {
                _logger.LogDebug("Succesfully inserted data {counter}", counter);
            }
            else
            {
                if (result.TryGetOriginalException(out var ex))
                    _logger.LogError(ex, "Error indexing data {counter}", counter);
                else
                    _logger.LogError("Error indexing data {counter}", counter);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
