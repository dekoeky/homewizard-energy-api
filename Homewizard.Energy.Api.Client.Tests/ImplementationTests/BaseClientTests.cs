using Homewizard.Energy.Api.Client.Clients;

namespace Homewizard.Energy.Api.Client.Tests.ImplementationTests;

[TestClass]
public class BaseClientTests
{
    [TestMethod]
    public async Task GetBasicInformation()
    {
        //Arrange
        var client = new BasicClient(TestDevices.GetHostName(DeviceTypes.EnergySocket));

        //Act
        var result = await client.GetBasicInformation();

        //Assert
        Console.WriteLine(result);
        Assert.IsNotNull(result);
    }
}
