namespace Homewizard.Energy.Api.Client.Models;

public class DeviceType
{
    public DeviceType(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }
    public string Type { get; }
}
