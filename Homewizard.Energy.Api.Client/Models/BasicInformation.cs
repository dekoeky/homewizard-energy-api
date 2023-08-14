using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

public class BasicInformation
{
    [JsonPropertyName("product_type")]
    public string? ProductType { get; set; }

    [JsonPropertyName("product_name")]
    public string? ProductName { get; set; }

    [JsonPropertyName("serial")]
    public string? Serial { get; set; }

    [JsonPropertyName("firmware_version")]
    public string? FirmwareVersion { get; set; }

    [JsonPropertyName("api_version")]
    public string? ApiVersion { get; set; }
}