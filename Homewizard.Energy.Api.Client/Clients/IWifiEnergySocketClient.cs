namespace Homewizard.Energy.Api.Client.Clients;

public interface IWifiEnergySocketClient : IBaseClient,
   Capabilities.IEnergySocketState,
   Capabilities.IIdentify,
   Capabilities.ISystemSettings,
   Capabilities.GetEnergySocketData
{

}
