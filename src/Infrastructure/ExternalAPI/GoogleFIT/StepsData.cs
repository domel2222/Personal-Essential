using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public record StepsData
    {
        public DateTime Stamp { get; init; }

        public int ActivityType { get; init; }
        
        public decimal StepCount { get; init; }

    }
}
