using Homewizard.Energy.Api.Client.Clients;

namespace Homewizard.Energy.Api.Client.Tests.ImplementationTests;

[TestClass]
public class WifiEnergySocketClientTests
{
    [TestMethod]
    public async Task foo()
    {
        //Arrange
        var client = new WifiEnergySocketClient(TestDevices.GetHostName(DeviceTypes.EnergySocket));

        //Act
        var result = await client.GetSocketData();

        //Assert
        Console.WriteLine(result);
        Assert.IsNotNull(result);
    }
}
