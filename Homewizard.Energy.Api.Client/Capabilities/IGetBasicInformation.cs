using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface IGetBasicInformation
{
    Task<BasicInformation?> GetBasicInformation(CancellationToken cancellationToken = default);
}