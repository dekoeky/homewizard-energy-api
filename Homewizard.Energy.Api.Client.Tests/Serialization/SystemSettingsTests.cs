using System.Diagnostics;
using System.Text.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Tests.Serialization;

[TestClass]
public class SystemSettingsTests : DataTestsBase
{
    [DataTestMethod]
    [DataRow("{\r\n   \"cloud_enabled\": false\r\n}\r\n", false)]
    [DataRow("{\r\n   \"cloud_enabled\": true\r\n}\r\n", true)]
    public void DeserializeTest(string json, bool expectedCloudEnabled)
    {
        //Act
        var data = JsonSerializer.Deserialize<SystemSettings>(json, options);

        //Assert
        Assert.IsNotNull(data);
        Assert.AreEqual(expectedCloudEnabled, data.CloudEnabled);
    }

    [TestMethod]
    public void SerializeTest()
    {
        //Arrange
        var data = new SystemSettings
        {
            CloudEnabled = true,
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
