using Homewizard.Energy.Api.Client.Models;

namespace ElasticInserterDemo.Models;

public class Data
{
    public DateTime TimeStamp { get; set; } = DateTime.Now;
    public uint Counter { get; set; }
    public BasicInformation? BasicInformation { get; set; }
    public HweSktData? SocketData { get; set; }
    public string? MachineName { get; set; }
}
