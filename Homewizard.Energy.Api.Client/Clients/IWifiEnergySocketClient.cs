namespace Homewizard.Energy.Api.Client.Clients;

public interface IWifiEnergySocketClient :
   Capabilities.IEnergySocketState,
   Capabilities.IIdentify,
   Capabilities.ISystemSettings
{

}