using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ConcurrentBag<string> _discovered;

    public WeatherForecastController(ConcurrentBag<string> discovered)
    {
        _discovered = discovered;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<string> Get()
    {
        return _discovered.ToArray();
    }
}
