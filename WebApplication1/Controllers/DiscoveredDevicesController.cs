using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscoveredDevicesController : ControllerBase
{
    private readonly ConcurrentBag<string> _discovered;

    public DiscoveredDevicesController(ConcurrentBag<string> discovered)
    {
        _discovered = discovered;
    }

    [HttpGet(Name = "GetDiscoveredDevices")]
    public IEnumerable<string> Get()
    {
        return _discovered.ToArray();
    }
}
