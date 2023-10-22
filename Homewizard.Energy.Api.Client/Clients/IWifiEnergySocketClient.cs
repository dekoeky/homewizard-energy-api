namespace Homewizard.Energy.Api.Client.Clients;

public interface IWifiEnergySocketClient : IBasicClient,
   Capabilities.IEnergySocketState,
   Capabilities.IIdentify,
   Capabilities.ISystemSettings,
   Capabilities.GetEnergySocketData
{

}
