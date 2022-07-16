
namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public record WeightDataPoint
    {
        public double? Weight { get; init; }
        public DateTime Stamp { get; init; }
        public double? MaxWeight { get; init; }
        public double? MinWeight { get; init; }
    }
}
