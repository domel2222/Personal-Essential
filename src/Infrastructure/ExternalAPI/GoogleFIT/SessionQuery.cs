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
        public SessionQuery(FitnessService fitnesService) :
                                            base(fitnesService)
        {
        }
        public IList<SessionDataPoint> GetSessionData(DateTime start, DateTime end, string activityType)
        {
            var listSession = ExecuteSessionRequest(start, end, activityType);

            return listSession
                    .Session
                    .Select(s =>
                    {
                        return new SessionDataPoint
                        {
                            Stamp = GoogleTimeHelper.CheckDifferenceDaysBetweenFromTwoMillisecondsResultToFloor(
                                s.StartTimeMillis, s.EndTimeMillis) == 0
                                    ? GoogleTimeHelper.FromMiliseconds(s.StartTimeMillis).ToDateTime().ToLocalTime()
                                    : GoogleTimeHelper.FromMiliseconds(s.EndTimeMillis).ToDateTime().ToLocalTime(),
                            //            .ToDateTime().ToLocalTime()
                            //((s.StartTimeMillis) - s.EndTimeMillis) != 0 ? GoogleTimeHelper.FromMiliseconds(s.StartTimeMillis)
                            //            .ToDateTime().ToLocalTime()
                            StartSession = GoogleTimeHelper.FromMiliseconds(s.StartTimeMillis)
                                        .ToDateTime().ToLocalTime(),
                            EndSession = GoogleTimeHelper.FromMiliseconds(s.EndTimeMillis)
                                        .ToDateTime().ToLocalTime(),
                            SessionName = s.Name,
                            SessionId = s.Id

                        };
                    }).ToList();

        }
        
        public IList<SessionDataPoint> GetSessionPerDay(DateTime start, DateTime end, string activityType)
        {
            return GetSessionData(start, end, activityType)
                .OrderBy(x => x.Stamp)
                .GroupBy(x => new { x.Stamp.Date, x.SessionName, x.SessionId })
                .Select(s => new SessionDataPoint
                {
                    Stamp = s.Key.Date,
                    SessionId = s.Key.SessionId,
                    SessionName = s.Key.SessionName,
                    StartSession = s.Select(x => x.StartSession).First(),
                    EndSession = s.Select(x => x.EndSession).First()
                })
                .ToList();
        }
    }
}
