
namespace Infrastructure.ExternalAPI.GoogleFIT.DataPoint
{
    public record StepsDataPoint
    {
        public DateTime Stamp { get; init; }

        public int ActivityType { get; init; }

        public decimal StepCount { get; init; }

    }
}
