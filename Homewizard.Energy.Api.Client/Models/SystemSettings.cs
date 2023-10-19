using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

public class SystemSettings
{
    [JsonPropertyName("cloud_enabled")]
    public bool? CloudEnabled { get; set; }
}
