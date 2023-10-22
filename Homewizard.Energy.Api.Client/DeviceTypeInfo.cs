namespace Homewizard.Energy.Api.Client;

public class DeviceTypeInfo
{
    public string Id { get; }
    public string Description { get; }
    public DeviceTypes DeviceType { get; }

    private DeviceTypeInfo(DeviceTypes deviceType, string id, string description)
    {
        Id = id;
        Description = description;
        DeviceType = deviceType;
    }

    public static readonly DeviceTypeInfo P1Meter = new(DeviceTypes.P1Meter, Ids.P1Meter, "Wi-Fi P1 meter");
    public static readonly DeviceTypeInfo EnergySocket = new(DeviceTypes.EnergySocket, Ids.EnergySocket, "Wi-Fi Energy Socket");
    public static readonly DeviceTypeInfo WaterMeter = new(DeviceTypes.WaterMeter, Ids.WaterMeter, "Wi-Fi Watermeter(Only when powered over USB)");
    public static readonly DeviceTypeInfo KwhMeter1Phase = new(DeviceTypes.KwhMeter1Phase, Ids.KwhMeter1Phase, "Wi-Fi kWh meter(1 phase)");
    public static readonly DeviceTypeInfo KwhMeter3Phase = new(DeviceTypes.KwhMeter3Phase, Ids.KwhMeter3Phase, "Wi-Fi kWh meter(3 phase)");

    internal static class Ids
    {
        public const string P1Meter = "HWE-P1";
        public const string EnergySocket = "HWE-SKT";
        public const string WaterMeter = "HWE-WTR";
        public const string KwhMeter1Phase = "SDM230-wifi";
        public const string KwhMeter3Phase = "SDM630-wifi";
    }

    public static IEnumerable<DeviceTypeInfo> All()
    {
        yield return P1Meter;
        yield return EnergySocket;
        yield return WaterMeter;
        yield return KwhMeter1Phase;
        yield return KwhMeter3Phase;
    }
}
