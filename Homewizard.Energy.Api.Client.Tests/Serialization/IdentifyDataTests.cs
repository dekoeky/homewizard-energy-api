using System.Diagnostics;
using System.Text.Json;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Tests.Serialization;

[TestClass]
public class IdentifyDataTests : DataTestsBase
{
    [TestMethod]
    public void DeserializeTest()
    {
        //Arrange
        const string json = "{\r\n   \"identify\": \"ok\",\r\n}";

        //Act
        var data = JsonSerializer.Deserialize<IdentifyData>(json, options);

        //Assert
        Assert.IsNotNull(data);
        Assert.AreEqual("ok", data.Identify);
    }

    [TestMethod]
    public void SerializeTest()
    {
        //Arrange
        var data = new IdentifyData
        {
            Identify = "ok",
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
