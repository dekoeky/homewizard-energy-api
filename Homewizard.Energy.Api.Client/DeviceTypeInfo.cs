namespace Homewizard.Energy.Api.Client;

public class DeviceTypeInfo
{
    public string DeviceType { get; }
    public string Device { get; }

    public DeviceTypeInfo(string device, string deviceType)
    {
        this.DeviceType = deviceType;
        this.Device = device;
    }

    public static readonly DeviceTypeInfo P1Meter = new("Wi-Fi P1 meter", "HWE-P1");
    public static readonly DeviceTypeInfo EnergySocket = new("Wi-Fi Energy Socket", "HWE-SKT");
    public static readonly DeviceTypeInfo WaterMeter = new("Wi-Fi Watermeter(Only when powered over USB)", "HWE-WTR");
    public static readonly DeviceTypeInfo KwhMeter1Phase = new("Wi-Fi kWh meter(1 phase)", "SDM230-wifi");
    public static readonly DeviceTypeInfo KwhMeter3Phase = new("Wi-Fi kWh meter(3 phase)", "SDM630-wifi");

    public static IEnumerable<DeviceTypeInfo> All()
    {
        yield return P1Meter;
        yield return EnergySocket;
        yield return WaterMeter;
        yield return KwhMeter1Phase;
        yield return KwhMeter3Phase;
    }
}
