using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class SessionQuery : FitnessQuery
    {
        public SessionQuery(FitnessService fitnesService, string dataSourceId, string dataType) :
                                            base(fitnesService, dataSourceId, dataType)
        {
        }
        private IList<SessionDataPoint> GetSessionData(DateTime start, DateTime end, string activityType)
        {
            var listSession = ExecuteSessionRequest(start, end, activityType);

            return listSession
                    .Session
                    .Select(s =>
                    {
                        return new SessionDataPoint
                        {
                            Stamp = GoogleTimeHelper.FromMiliseconds(s.StartTimeMillis)
                                        .ToDateTime().ToLocalTime(),
                            StartSession = GoogleTimeHelper.FromMiliseconds(s.StartTimeMillis)
                                        .ToDateTime().ToLocalTime(),
                            EndSession = GoogleTimeHelper.FromMiliseconds(s.EndTimeMillis)
                                        .ToDateTime().ToLocalTime(),
                            SessionName = s.Name

                        };
                    }).ToList();

        }
        

    }
}
