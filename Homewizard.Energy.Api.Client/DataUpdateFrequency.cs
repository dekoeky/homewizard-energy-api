namespace Homewizard.Energy.Api.Client;

public static class DataUpdateFrequency
{
    public static readonly TimeSpan AdvicedMinimumPollingTime = TimeSpan.FromMilliseconds(500);

    public static class PreVersionSMR5_0
    {
        public static readonly TimeSpan Gas = TimeSpan.FromMinutes(60);
        public static readonly TimeSpan Electricity = TimeSpan.FromSeconds(10);
    }
    public static class VersionSMR5_0AndUp
    {
        public static readonly TimeSpan Gas = TimeSpan.FromMinutes(5);
        public static readonly TimeSpan Electricity = TimeSpan.FromSeconds(1);
    }
}