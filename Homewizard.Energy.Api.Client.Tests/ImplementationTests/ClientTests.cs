using Homewizard.Energy.Api.Client.Clients;

namespace Homewizard.Energy.Api.Client.Tests.ImplementationTests;

[TestClass]
public class ClientTests
{
    [TestMethod]
    public async Task foo()
    {
        //Arrange
        IWifiEnergySocketClient client = new Clients.Client(new HttpClient() { BaseAddress = new Uri("http://192.168.0.242") });

        //Act
        var result = await client.GetState();

        //Assert
        Console.WriteLine(result);
        Assert.IsNotNull(result);
    }
}