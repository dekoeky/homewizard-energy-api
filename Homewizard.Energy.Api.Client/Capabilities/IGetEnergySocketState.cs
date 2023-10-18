using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface IGetEnergySocketState
{
    Task<EnergySocketStateData?> GetState(CancellationToken cancellationToken = default);

}