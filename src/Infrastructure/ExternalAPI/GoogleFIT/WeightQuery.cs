
using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class WeightQuery : FitnessQuery
    {
        private const string DataSourceId = "derived:com.google.weight:com.google.android.gms:merge_weight";
        private const string DataType = "com.google.weight.summary";
        public WeightQuery(FitnessService fitnesService) :
                            base(fitnesService, DataSourceId, DataType)
        {
        }

        private  IList<WeightDataPoint> GetQueryWeight(DateTime start, DateTime end)
        {
            var request = CreateRequest(start, end);
            var response = ExecuteRequest(request);

            return  response
                    .Bucket
                    .SelectMany(x => x.Dataset)
                    .Where(x => x.Point != null)
                    .SelectMany(x => x.Point)
                    .Where(p => p.Value != null)
                    .SelectMany(p =>
                    {
                        return p.Value.Select(x =>
                                        new WeightDataPoint()
                                        {
                                            Weight = x.FpVal.GetValueOrDefault(),
                                            Stamp = GoogleTimeHelper.FromNanoseconds(p.StartTimeNanos).ToDateTime().ToLocalTime()
                                        }) ;
                    })
                    .ToList();
        }

        public IList<WeightDataPoint> GetQueryWeightPerDay(DateTime start, DateTime end)
        {
            return GetQueryWeight(start, end)
                    .OrderBy(x => x.Stamp)
                    .GroupBy(x => x.Stamp.Date)
                    .Select(q => new WeightDataPoint
                    {
                        Stamp = q.Key,
                        Weight = q.Select(w => w.Weight).First(),
                        MaxWeight = q.Max(w => w.Weight),
                        MinWeight = q.Min(w => w.Weight),

                    })
                    .ToList();
        }
    }
}
