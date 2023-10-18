using Homewizard.Energy.Api.Client.Capabilities;
using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Clients;

public interface IClient : IGetBasicInformation
{
    Task<HweSktData?> GetSocketData(CancellationToken cancellationToken = default);
}