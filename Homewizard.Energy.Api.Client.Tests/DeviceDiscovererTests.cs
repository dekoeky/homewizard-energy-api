namespace Homewizard.Energy.Api.Client.Tests;

[TestClass]
public class DeviceDiscovererTests
{
    [TestMethod]
    public async Task Discover()
    {
        //Arrange
        using var discoverer = new DeviceDiscoverer();

        //Act
        var items = await discoverer.Discover(TimeSpan.FromSeconds(5));


        //Assert
        if (items.Any())
            foreach (var item in items)
                Console.WriteLine($"Discovered: {item}");
        else
            Console.WriteLine("No devices discovered");

        Assert.IsTrue(items.Any());
    }
}