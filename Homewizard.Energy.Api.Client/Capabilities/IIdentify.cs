using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface IIdentify
{
    Task<IdentifyData?> Identify(CancellationToken cancellationToken = default);
}