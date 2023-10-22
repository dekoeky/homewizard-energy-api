using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client;

public static class Hostname
{
    public static string CalculateHostname(this BasicInformation info)
    {
        var prefix = GetPrefix(info.ProductType);
        var last6 = info.Serial[^6..].ToUpper();
        return $"{prefix}-{last6}.local";
    }

    public static string CalculateHostname(string serial, DeviceTypes deviceType)
    {
        var prefix = GetPrefix(deviceType);
        var suffix = serial[^6..].ToUpper();
        return $"{prefix}-{suffix}.local";
    }

    private static string GetPrefix(string? productType) => productType switch
    {
        DeviceTypeInfo.Ids.EnergySocket => GetPrefix(DeviceTypes.EnergySocket),
        DeviceTypeInfo.Ids.P1Meter => GetPrefix(DeviceTypes.P1Meter),
        DeviceTypeInfo.Ids.WaterMeter => GetPrefix(DeviceTypes.WaterMeter),
        DeviceTypeInfo.Ids.KwhMeter1Phase => GetPrefix(DeviceTypes.KwhMeter1Phase),
        DeviceTypeInfo.Ids.KwhMeter3Phase => GetPrefix(DeviceTypes.KwhMeter3Phase),

        _ => throw new NotImplementedException(),
    }; private static string GetPrefix(DeviceTypes? productType) => productType switch
    {
        DeviceTypes.EnergySocket => "energysocket",
        DeviceTypes.P1Meter => "p1meter",
        DeviceTypes.WaterMeter => "watermeter",
        DeviceTypes.KwhMeter1Phase or
            DeviceTypes.KwhMeter3Phase => "energymeter",

        _ => throw new NotImplementedException(),
    };
}
