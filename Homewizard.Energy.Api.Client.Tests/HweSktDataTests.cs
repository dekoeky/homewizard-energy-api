using Homewizard.Energy.Api.Client.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Homewizard.Energy.Api.Client.Tests;

[TestClass]
public class HweSktDataTests
{
    private static readonly JsonSerializerOptions options = new()
    {
        AllowTrailingCommas = true,
        WriteIndented = true,
    };

    [TestMethod]
    public void DeserializeTest()
    {
        //Arrange
        const string json = @"{
   ""wifi_ssid"": ""My Wi-Fi"",
   ""wifi_strength"": 100,
   ""total_power_import_t1_kwh"": 30.511,
   ""total_power_export_t1_kwh"": 85.951,
   ""active_power_w"": 543,
   ""active_power_l1_w"": 676,
}";

        //Act
        var data = JsonSerializer.Deserialize<HweSktData>(json, options);

        //Assert
        Assert.IsNotNull(data);
        Assert.AreEqual("My Wi-Fi", data.WifiSsid);
        Assert.AreEqual(100, data.WifiStrength);
        Assert.AreEqual(30.511, data.TotalPowerImportT1);
        Assert.AreEqual(543, data.ActivePower);
        Assert.AreEqual(676, data.ActivePowerL1);
    }

    [TestMethod]
    public void SerializeTest()
    {
        //Arrange
        var data = new HweSktData
        {

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