using System.Diagnostics;
using System.Text.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Tests.Serialization;

[TestClass]
public class HweSktDataTests : DataTestsBase
{
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
            ActivePower = 100.23,
            ActivePowerL1 = 200.46,
            WifiSsid = "ssid",
            WifiStrength = 53.1,
            TotalPowerExportT1 = 123.4,
            TotalPowerImportT1 = 1450.1,
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
