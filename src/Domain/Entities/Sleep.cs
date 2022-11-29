using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sleep : AuditableEntity
    {
        public int LengthOfSleepiInMinutes { get; set;}
        public TimeSpan WakeUp { get; set;}
        public TimeSpan FallingAsleep { get; set;}
        public DateTime DateSleep { get; set;}

    }
}
