using Homewizard.Energy.Api.Client.Clients;
using MongoDB.Driver;
using MongoInserterDemo;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger());


builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(builder.Configuration["ConnectionString"] ?? throw new NullReferenceException()));
builder.Services.AddHttpClient<IWifiEnergySocketClient, WifiEnergySocketClient>(options => options.BaseAddress = new Uri("http://192.168.0.242"));
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
