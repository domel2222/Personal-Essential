using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Strenght : AuditableEntity
    {
        public string? Name { get; set; }
        public IEnumerable<MostWinDuringTheDay> MostWinsDuringTheDay { get; set; } = new List<MostWinDuringTheDay>();
    }
}
