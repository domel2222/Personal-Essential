
namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public record WeightDataPoint
    {
        public double? Weight { get; set; }
        public DateTime Stamp { get; set; }
        public double? MaxWeight { get; set; }
        public double? MinWeight { get; set; }
    }
}
