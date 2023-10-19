using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface ISetEnergySocketState

{
    Task<EnergySocketStateData?> SetState(EnergySocketStateData wantedState, CancellationToken cancellationToken = default);
}