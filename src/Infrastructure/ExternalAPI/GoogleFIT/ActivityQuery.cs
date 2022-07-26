namespace Infrastructure.ExternalAPI.GoogleFIT.DataPoint
{
    public class ActivityQuery : FitnessQuery
    {
        private const string DataSourceId = "derived:com.google.step_count.delta:com.google.android.gms:estimated_steps";
        private const string DataType = "com.google.step_count.delta";
        public ActivityQuery(FitnessService fitnesService) :
                            base(fitnesService, DataSourceId, DataType)
        {

        }
        private IList<StepsDataPoint> GetQuerySteps(DateTime start, DateTime end)
        {
            var request = CreateRequest(start, end);
            var response = ExecuteRequest(request);

            return response
                    .Bucket
                    .SelectMany(x => x.Dataset)
                    .Where(x => x.Point != null)
                    .SelectMany(x => x.Point)
                    .Where(p => p.Value != null)
                    .SelectMany(p =>
                    {
                        return p.Value.Select(x =>
                                        new StepsDataPoint()
                                        {
                                            StepCount = x.IntVal.GetValueOrDefault(),
                                            Stamp = GoogleTimeHelper.FromNanoseconds(p.StartTimeNanos).ToDateTime().ToLocalTime()
                                            // problem with time - diffrences bettwen google and local time - how to set actualt date time - culture.
                                        });
                    })
                    .ToList();
        }

        public IList<StepsDataPoint> GetQueryStepsPerDay(DateTime start, DateTime end)
        {
            return GetQuerySteps(start, end)
                    .OrderBy(x => x.Stamp)
                    .GroupBy(x => x.Stamp.Date)
                    .Select(q => new StepsDataPoint
                    {
                        Stamp = q.Key,
                        StepCount = q.Max(x => x.StepCount)

                    })
                    .ToList();
        }

        public IQueryable<StepsDataPoint> GetQueryStepsAsync(DateTime start, DateTime end)
        //public Task<StepsData> GetQueryStepsAsync(DateTime start, DateTime end)
        {
            var request = CreateRequest(start, end);
            var response = ExecuteRequestAsync(request);

            return (IQueryable<StepsDataPoint>) response
                    .Result
                    .Bucket
                    .SelectMany(x => x.Dataset)
                    .Where(x => x.Point != null)
                    .SelectMany(x => x.Point)
                    .Where(p => p.Value != null)
                    .SelectMany(p =>
                    {
                        return p.Value.Select(x =>
                                        new StepsDataPoint()
                                        {
                                            StepCount = x.IntVal.GetValueOrDefault(),
                                            Stamp = GoogleTimeHelper.FromNanoseconds(p.StartTimeNanos).ToDateTime()
                                        });
                    });
                    
        }
        // Do I have any gain from such a solution - or i have to use IAsyncEnumarable
        //public Task<StepsData> GetAmoutStepByDayAsync(DateTime start, DateTime end)
        public IQueryable<StepsDataPoint> GetAmoutStepByDayAsync(DateTime start, DateTime end)
        {
            return (IQueryable<StepsDataPoint>)GetQuerySteps(start, end)
                    .OrderBy(x => x.Stamp)
                    .GroupBy(x => x.Stamp.Date)
                    .Select(q => new StepsDataPoint
                    {
                        Stamp = q.Key,
                        StepCount = q.Sum(x => x.StepCount)

                    });
        }
    }

}
