using Homewizard.Energy.Api.Client.Clients;
using MongoDB.Driver;
using MongoInserterDemo.Models;

namespace MongoInserterDemo;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IWifiEnergySocketClient socketClient;
    private readonly IMongoClient _mongoClient;

    public Worker(ILogger<Worker> logger, IWifiEnergySocketClient socketClient, IMongoClient mongoClient)
    {
        _logger = logger;
        this.socketClient = socketClient;
        this._mongoClient = mongoClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var db = _mongoClient.GetDatabase("homewizard");
        var col = db.GetCollection<Data>("data");

        uint counter = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            var data = new Data
            {
                Counter = ++counter,
                BasicInformation = await socketClient.GetBasicInformation(stoppingToken),
                SocketData = await socketClient.GetSocketData(stoppingToken),
                MachineName = Environment.MachineName,
            };

            try
            {
                await col.InsertOneAsync(data, new InsertOneOptions(), stoppingToken);

                _logger.LogDebug("Succesfully inserted data {counter}", counter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error indexing data {counter}", counter);

            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
