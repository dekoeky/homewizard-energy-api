using Homewizard.Energy.Api.Client;
using Homewizard.Energy.Api.Client.Clients;
using Homewizard.Energy.Api.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerSocketController : ControllerBase
{
    [HttpGet("GetWeatherForecast/{serial}")]
    public async Task<BasicInformation?> GetAsync(string serial, CancellationToken token = default)
    {
        var hostname = Hostname.CalculateHostname(serial, DeviceTypes.EnergySocket);

        //var client = new WifiEnergySocketClient($"http://{hostname}");
        var client = new WifiEnergySocketClient("http://192.168.0.242");
        var info = await client.GetBasicInformation(token);

        return info;
    }
}
