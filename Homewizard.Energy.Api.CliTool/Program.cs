
using Homewizard.Energy.Api.Client.Clients;
using Homewizard.Energy.Api.CliTool;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger());

builder.Services.AddHttpClient<IWifiEnergySocketClient, WifiEnergySocketClient>(o => o.BaseAddress = new Uri(
    builder.Configuration["Uri"] ?? throw new Exception("Uri not provided")));
builder.Services.AddHostedService<Worker>();


var host = builder.Build();

host.Run();
