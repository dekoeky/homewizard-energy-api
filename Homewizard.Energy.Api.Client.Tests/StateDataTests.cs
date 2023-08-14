using Homewizard.Energy.Api.Client.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Homewizard.Energy.Api.Client.Tests;

[TestClass]
public class StateDataTests
{
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        WriteIndented = true,
    };


    [TestMethod]
    public void DeserializeTest()
    {
        //Arrange
        const string json = "{\r\n   \"power_on\": true,\r\n   \"switch_lock\": false,\r\n   \"brightness\": 255\r\n}";

        //Act
        var data = JsonSerializer.Deserialize<StateData>(json, options);

        //Assert
        Assert.IsNotNull(data);
        Assert.AreEqual(true, data.PowerOn);
        Assert.AreEqual(false, data.SwitchLock);
        Assert.AreEqual(255, data.Brightness);
    }

    [TestMethod]
    public void SerializeTest()
    {
        //Arrange
        var data = new StateData
        {
            PowerOn = true,
            SwitchLock = false,
            Brightness = 255,
        };

        //Act
        var json = JsonSerializer.Serialize(data, options);

        //Assert
        Assert.IsNotNull(data);
        Assert.IsFalse(string.IsNullOrEmpty(json));
        Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        Debug.WriteLine(json);
    }
}