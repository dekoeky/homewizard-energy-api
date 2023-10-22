using System.Diagnostics;
using System.Text.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Tests.Serialization;

[TestClass]
public class BasicInformationTests : DataTestsBase
{
    [TestMethod]
    public void DeserializeTest()
    {
        //Arrange
        const string json = @"{
    ""product_type"": ""HWE-P1"",
    ""product_name"": ""P1 Meter"",
    ""serial"": ""3c39e7aabbcc"",
    ""firmware_version"": ""2.11"",
    ""api_version"": ""v1""
}";

        //Act
        var data = JsonSerializer.Deserialize<BasicInformation>(json, options);

        //Assert
        Assert.IsNotNull(data);
        Assert.AreEqual("HWE-P1", data.ProductType);
        Assert.AreEqual("P1 Meter", data.ProductName);
        Assert.AreEqual("3c39e7aabbcc", data.Serial);
        Assert.AreEqual("2.11", data.FirmwareVersion);
        Assert.AreEqual("v1", data.ApiVersion);
    }

    [TestMethod]
    public void SerializeTest()
    {
        //Arrange
        var data = new BasicInformation
        {
            ProductType = "HWE-P1",
            ProductName = "P1 Meter",
            Serial = "3c39e7aabbcc",
            FirmwareVersion = "2.11",
            ApiVersion = "v1",
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
