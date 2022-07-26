using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPI.GoogleFIT.Interfaces
{
    public interface IActiveFitnessGoogleApi
    {
        IList<StepsDataPoint> GetQueryStepsPerDay(DateTime start, DateTime end);
        Task<StepsDataPoint> GetQueryStepsPerDayAsync(DateTime start, DateTime end);

    }
}
