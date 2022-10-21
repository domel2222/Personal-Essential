using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MostWinDuringTheDay : AuditableEntity
    {
           public string? Message { get; set;}


           public Journal? Journal { get; set;}
           public Guid JournalId { get; set;}
        public Strenght? Strenght { get; set; }
        public Guid StrenghtId { get; set; }
    }
}
