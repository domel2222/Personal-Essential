using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IWeightFitnessGoogleApi
    {
        IList<WeightDataPoint> GetQueryWeightPerDay(DateTime start, DateTime end);
    }
    
}
