using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface ISetSystemSettings
{
    Task<SystemSettings?> GetSystemSettings(CancellationToken cancellationToken = default);
}