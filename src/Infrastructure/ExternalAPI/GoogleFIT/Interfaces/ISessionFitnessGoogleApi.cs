using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPI.GoogleFIT.Interfaces
{
    public interface ISessionFitnessGoogleApi
    {
        //GetSession(DateTime start, DateTime end, string activityType)
        IList<SessionDataPoint> GetSessionPerDay(DateTime start, DateTime end, string activityType);
    }
}
