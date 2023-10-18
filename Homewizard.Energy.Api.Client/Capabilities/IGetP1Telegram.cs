using Homewizard.Energy.Api.Client.Models;

namespace Homewizard.Energy.Api.Client.Capabilities;

public interface IGetP1Telegram
{
    Task<P1Telegram?> GetBasicInformation(CancellationToken cancellationToken = default);
}