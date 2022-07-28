
namespace Infrastructure.ExternalAPI.GoogleFIT.DataPoint
{
    public record SessionDataPoint
    {
        public DateTime Stamp { get; init; }
        public DateTime StartSession { get; init; }
        public DateTime EndSession { get; init; }
        public string? SessionName { get; init; }
        public string? SessionId { get; init; }

    }
}
