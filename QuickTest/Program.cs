


using Makaretu.Dns;

//var sd = new ServiceDiscovery();
//sd.ServiceDiscovered += (s, serviceName) =>
//{
//    Console.WriteLine($"{serviceName.Labels}");
//};
//sd.ServiceInstanceDiscovered += (s, serviceName) =>
//{
//    Console.WriteLine($"{serviceName.RemoteEndPoint}");
//};





//var service = "appletv.local";
//service = "_hwenergy._tcp";
//var query = new Message()
//{
//    Questions =
//    {
//        new Question {Name = service, Type = DnsType.ANY}
//    }
//};

//var cancellation = new CancellationTokenSource();

//using (var mdns = new MulticastService())
//{
//    mdns.Start();
//    var response = await mdns.ResolveAsync(query, cancellation.Token);
//    // Do something

//    Console.WriteLine("Response");
//}




var device = new DomainName("energysocket-0CCF04", "_hwenergy", "_tcp", "local");






var domain = new DomainName("_hwenergy", "_tcp");




















//var service = new ServiceProfile("x", "_hwenergy._tcp", 1024);
var sd = new ServiceDiscovery();
//sd.Advertise(service);
sd.ServiceInstanceDiscovered += Sd_ServiceInstanceDiscovered;
sd.ServiceDiscovered += Sd_ServiceDiscovered;
sd.ServiceInstanceShutdown += Sd_ServiceInstanceShutdown;

//sd.QueryAllServices(); //Good
sd.QueryServiceInstances(domain);
//sd.QueryUnicastServiceInstances(new DomainName("_hwenergy", "_tcp"));

//sd.que







Console.WriteLine("Scanning...");
Console.ReadKey();

return;



void Sd_ServiceInstanceShutdown(object? sender, ServiceInstanceShutdownEventArgs e)
{
    Console.WriteLine("Sd_ServiceInstanceShutdown");
    Console.WriteLine($"{e.ServiceInstanceName} @ {e.RemoteEndPoint} : {e.Message}");
}

void Sd_ServiceDiscovered(object? sender, DomainName e)
{
    return;
    Console.WriteLine("Sd_ServiceDiscovered");
    foreach (var label in e.Labels)
        Console.WriteLine($"    {label}");

    if (e.BelongsTo(domain))
        Console.WriteLine("Belongs To HomeWizard");
    else
        Console.WriteLine("????");

}

void Sd_ServiceInstanceDiscovered(object? sender, ServiceInstanceDiscoveryEventArgs e)
{
    Console.WriteLine("Sd_ServiceInstanceDiscovered");
    Console.WriteLine($"{e.ServiceInstanceName} @ {e.RemoteEndPoint} : {e.Message}");

    if (e.ServiceInstanceName.BelongsTo(domain))
        Console.WriteLine("Belongs To HomeWizard");
    else
        Console.WriteLine("????");

}