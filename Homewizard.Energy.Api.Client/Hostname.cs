using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client;

public static class Hostname
{
    public static string CalculateHostname(this BasicInformation info)
    {
        var prefix = GetPrefix(info.ProductType);
        var last6 = info.Serial[^6..].ToUpper();
        return $"{prefix}-{last6}";
    }

    private static string GetPrefix(string? productType) => productType switch
    {
        DeviceTypeInfo.Ids.EnergySocket => "energysocket",
        DeviceTypeInfo.Ids.P1Meter => "p1meter",
        DeviceTypeInfo.Ids.WaterMeter => "watermeter",
        DeviceTypeInfo.Ids.KwhMeter1Phase or
        DeviceTypeInfo.Ids.KwhMeter3Phase => "energymeter",

        _ => throw new NotImplementedException(),
    };
}
