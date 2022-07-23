
namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public abstract class FitnessQuery
    {
        private FitnessService _fitnessService;
        private string _dataSourceId;
        private string _dataType;

        public FitnessQuery(FitnessService fitnesService, string dataSourceId, string dataType)
        {
            _fitnessService = fitnesService;
            _dataSourceId = dataSourceId;
            _dataType = dataType;
        }

        protected virtual AggregateRequest CreateRequest(DateTime start, DateTime end, TimeSpan? bucketDuration = null)
        {
            var bucketTimeSpan = bucketDuration.GetValueOrDefault(TimeSpan.FromDays(1));

            return new AggregateRequest
            {
                AggregateBy = new AggregateBy[]
                {
                    new AggregateBy
                    {
                        DataSourceId = _dataSourceId,
                        DataTypeName = _dataType
                    }
                },

                BucketByTime = new BucketByTime
                {
                    DurationMillis = (long)bucketTimeSpan.TotalMilliseconds
                },

                StartTimeMillis = GoogleTimeHelper.FromDateTime(start).TotalMilliseconds,
                EndTimeMillis = GoogleTimeHelper.FromDateTime(end).TotalMilliseconds
            };
        }

        protected virtual AggregateResponse ExecuteRequest(AggregateRequest aggregateRequest, string userId = "me")
        {
            var aggregate = _fitnessService.Users.Dataset.Aggregate(aggregateRequest, userId);
            return aggregate.Execute();
        }

        protected virtual Task<AggregateResponse> ExecuteRequestAsync(AggregateRequest aggregateRequest, string userId = "me")
        {
            var aggregate = _fitnessService.Users.Dataset.Aggregate(aggregateRequest, userId);
            return aggregate.ExecuteAsync();
        }
    }
}
