using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client;

public interface IClient
{
    Task<BasicInformation?> GetBasicInformation(CancellationToken cancellationToken = default);
    Task<HweSktData?> GetDataFromSocket(CancellationToken cancellationToken = default);
    Task<IdentifyData?> GetIdentify(CancellationToken cancellationToken = default);
    Task<SystemStateData?> GetSystem(CancellationToken cancellationToken = default);
}