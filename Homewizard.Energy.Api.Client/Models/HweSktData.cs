using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

public class HweSktData : WifiDataBase
{
    /// <summary>
    /// The power usage meter reading for tariff 1 in kWh
    /// </summary>
    [JsonPropertyName("total_power_import_t1_kwh")]
    public double? TotalPowerImportT1 { get; set; }

    /// <summary>
    /// The power usage meter reading for tariff 1 in kWh
    /// </summary>
    [JsonPropertyName("total_power_export_t1_kwh")]
    public double? TotalPowerExportT1 { get; set; }

    /// <summary>
    /// The total active usage in watt
    /// </summary>
    [JsonPropertyName("active_power_w")]
    public double? ActivePower { get; set; }

    /// <summary>
    /// The active usage for phase 1 in watt
    /// </summary>
    [JsonPropertyName("active_power_l1_w")]
    public double? ActivePowerL1 { get; set; }
}