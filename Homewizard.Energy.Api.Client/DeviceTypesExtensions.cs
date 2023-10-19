namespace Homewizard.Energy.Api.Client;

public static class DeviceTypesExtensions
{
    public static DeviceTypeInfo GetInfo(this DeviceTypes type) => type switch
    {
        DeviceTypes.P1Meter => DeviceTypeInfo.P1Meter,
        DeviceTypes.EnergySocket => DeviceTypeInfo.EnergySocket,
        DeviceTypes.WaterMeter => DeviceTypeInfo.WaterMeter,
        DeviceTypes.KwhMeter1Phase => DeviceTypeInfo.KwhMeter1Phase,
        DeviceTypes.KwhMeter3Phase => DeviceTypeInfo.KwhMeter3Phase,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}
