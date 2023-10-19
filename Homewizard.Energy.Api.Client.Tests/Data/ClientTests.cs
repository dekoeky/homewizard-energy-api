using System.Diagnostics;

namespace Homewizard.Energy.Api.Client.Tests.Data;

[TestClass]
public class DeviceTypesTests
{
    [TestMethod]
    public void AllDeviceTypesHaveInfo()
    {
        //Arrange
        var types = Enum.GetValues<DeviceTypes>();

        foreach (var item in types)
        {
            //Act
            var info = item.GetInfo();

            //Assert
            Assert.IsNotNull(info);
            Assert.IsFalse(string.IsNullOrEmpty(info.Device));
            Assert.IsFalse(string.IsNullOrEmpty(info.DeviceType));
            Debug.WriteLine($"{item} -> '{info.DeviceType}' - {info.Device} ");
        }
    }
}
