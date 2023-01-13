using Domain.Common;

namespace Domain.Entities
{
    public class MostWinDuringTheDay : AuditableEntity
    {
        public string? Message { get; set; }
        public DateTime WinDate { get; set; }
        public Journal? Journal { get; set; }
        public Guid JournalId { get; set; }
        public Strenght? Strenght { get; set; }
        public Guid StrenghtId { get; set; } 
    }
}