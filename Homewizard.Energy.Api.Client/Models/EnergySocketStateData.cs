using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

public class EnergySocketStateData
{
    /// <summary>
    /// When set to true, the socket cannot be turned off.
    /// </summary>
    [JsonPropertyName("power_on")]
    public bool? PowerOn { get; set; }

    /// <summary>
    /// When set to true, the socket cannot be turned off.
    /// </summary>
    [JsonPropertyName("switch_lock")]
    public bool? SwitchLock { get; set; }

    /// <summary>
    /// Brightness of LED ring when socket is ‘on’. Value from 0 (0%) to 255 (100%)
    /// </summary>
    [JsonPropertyName("brightness")]
    public byte? Brightness { get; set; }
}