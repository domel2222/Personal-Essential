using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sleep
    {
        public int LengthOfSleepiInMinutes { get; set;}
        public TimeSpan WakeUp { get; set;}
        public TimeSpan FallingAsleep { get; set;}
        public DateOnly DateSleep { get; set;}

    }
}
