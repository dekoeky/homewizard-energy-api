using System.Text.Json;

namespace Homewizard.Energy.Api.Client.Tests.Serialization;

public class DataTestsBase
{
    protected static readonly JsonSerializerOptions options = new()
    {
        AllowTrailingCommas = true,
        WriteIndented = true,
    };


}