using System.Text.Json.Serialization;

namespace Homewizard.Energy.Api.Client.Models;

public class Error
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
}
