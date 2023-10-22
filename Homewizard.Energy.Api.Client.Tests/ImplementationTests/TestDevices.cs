using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Homewizard.Energy.Api.Client.Tests.ImplementationTests;

public static class TestDevices
{
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly())
        .Build();

    public static string GetHostName(DeviceTypes deviceType) => deviceType switch
    {
        DeviceTypes.EnergySocket => Configuration["hostnames:powersocket"],

        _ => throw new NotImplementedException(),
    };
}
