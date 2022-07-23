using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPI.GoogleFIT.Interfaces
{
    public interface IActiveFitnessGoogleApi
    {
        IList<StepsData> GetQueryStepsPerDay(DateTime start, DateTime end);
        Task<StepsData> GetQueryStepsPerDayAsync(DateTime start, DateTime end);

    }
}
