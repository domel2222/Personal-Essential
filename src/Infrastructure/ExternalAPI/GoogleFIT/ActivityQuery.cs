using Google.Apis.Fitness.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class ActivityQuery : FitnessQuery
    {
        private const string DataSourceId = "derived:com.google.step_count.delta:com.google.android.gms:estimated_steps";
        private const string DataType = "com.google.step_count.delta";
        public ActivityQuery(FitnessService fitnesService) : 
                            base(fitnesService, DataSourceId, DataType)
        {
        }
    }
}
