using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

public class IdentifyData
{
    [JsonPropertyName("identify")]
    public string? Identify { get; set; }
}
