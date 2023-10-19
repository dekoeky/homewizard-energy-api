using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticInserterDemo.Services;
using Homewizard.Energy.Api.Client.Clients;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger());

const string url = "https://elastic:elastic@host.docker.internal:9200";
var settings = new ElasticsearchClientSettings(new Uri(url));
#warning Cerver Certificate ignored
settings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);

settings.DefaultMappingFor<ElasticInserterDemo.Models.Data>(f => f.IndexName("data"));

builder.Services.AddSingleton<IElasticsearchClientSettings>(settings);
builder.Services.AddSingleton<ElasticsearchClient>();
builder.Services.AddHttpClient<IWifiEnergySocketClient, WifiEnergySocketClient>(options => options.BaseAddress = new Uri("http://192.168.0.242"));
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
