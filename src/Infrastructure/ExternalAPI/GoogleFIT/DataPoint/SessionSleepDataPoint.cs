
namespace Infrastructure.ExternalAPI.GoogleFIT.DataPoint
{
    public record SessionSleepDataPoint
    {
        public DateTime Stamp { get; init; }
        public DateTime StartSleep { get; init; }
        public DateTime EndSleep { get; init; }
    }
}
