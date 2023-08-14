using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

/// <summary>
/// Base type for Wifi Device Data types
/// </summary>
public abstract  class WifiDataBase
{
    /// <summary>
    /// The Wi-Fi network that the meter is connected to
    /// </summary>
    [JsonPropertyName("wifi_ssid")]
    public string? WifiSsid { get; set; }

    /// <summary>
    /// The strength of the Wi-Fi signal in %
    /// </summary>
    [JsonPropertyName("wifi_strength")]
    public double? WifiStrength { get; set; }
}