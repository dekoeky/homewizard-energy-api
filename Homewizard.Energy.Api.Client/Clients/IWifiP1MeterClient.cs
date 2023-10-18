
namespace Homewizard.Energy.Api.Client.Clients;

public interface IWifiP1MeterClient :
    Capabilities.IGetP1Telegram,
    Capabilities.IIdentify,
    Capabilities.ISystemSettings
{

}