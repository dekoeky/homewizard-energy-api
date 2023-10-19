using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticInserterDemo.Services;
using Homewizard.Energy.Api.Client.Clients;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger());

var settings = new ElasticsearchClientSettings(builder.Configuration.GetValue<Uri>("ElasticSearch:Url"));
#warning Cerver Certificate ignored
settings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);
settings.Authentication(new BasicAuthentication(
    builder.Configuration["ElasticSearch:Username"] ?? throw new Exception("ElasticSearch Username Missing"),
    builder.Configuration["ElasticSearch:Password"] ?? throw new Exception("ElasticSearch Password Missing")
));
settings.DefaultMappingFor<ElasticInserterDemo.Models.Data>(f => f.IndexName("data"));

builder.Services.AddSingleton<IElasticsearchClientSettings>(settings);
builder.Services.AddSingleton<ElasticsearchClient>();
builder.Services.AddHttpClient<IWifiEnergySocketClient, WifiEnergySocketClient>(options => options.BaseAddress = new Uri("http://192.168.0.242"));
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
