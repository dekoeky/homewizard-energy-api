using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface GetEnergySocketData
{
    Task<HweSktData?> GetSocketData(CancellationToken cancellationToken = default);
}
