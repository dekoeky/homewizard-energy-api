using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface IGetSystemSettings
{
    Task<SystemSettings?> SetSystemSettings(SystemSettings settings, CancellationToken cancellationToken = default);
}