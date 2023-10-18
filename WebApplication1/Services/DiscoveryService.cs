using System.Net;
using System.Net.NetworkInformation;

namespace WebApplication1.Controllers;

public class DiscoveryService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var nic in GetNics())
            ScanNic(nic);

        return Task.CompletedTask;
    }

    private IEnumerable<NetworkInterface> GetNics()
    {
        var nics = NetworkInterface.GetAllNetworkInterfaces();

        //var x = nics
        //    .Where(n => n.OperationalStatus == OperationalStatus.Up)
        //    .Where(n => n.NetworkInterfaceType == )
        //;

        return nics;
    }

    private void ScanNic(NetworkInterface nic)
    {
        if (nic.OperationalStatus != OperationalStatus.Up)
            return;
        if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback)
            return;

        var props = nic.GetIPProperties();

        foreach (UnicastIPAddressInformation x in props.UnicastAddresses)
        {
            if (x.Address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                continue;

            //var address = x.Address;
            //var mask = x.IPv4Mask;

            Console.WriteLine($"Address: {x.Address}");
            Console.WriteLine($"Mask: {x.IPv4Mask}");
            Console.WriteLine($"Mask: {x.Address.AddressFamily}");
            Console.WriteLine($"Nic Type: {nic.NetworkInterfaceType}");
            Console.WriteLine();

        }


    }

    private void Maskies(IPAddress address, IPAddress mask)
    {
        //172.21.64.1       --> 20977068
        //255.255.240.0     --> 15794175
    }
}
