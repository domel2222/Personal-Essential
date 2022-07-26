
using System.Threading;
using static Google.Apis.Fitness.v1.UsersResource.SessionsResource;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public abstract class FitnessQuery
    {
        private FitnessService _fitnessService;
        private string? _dataSourceId;
        private string? _dataType;
        private CancellationToken _cancellationToken;

        public FitnessQuery(FitnessService fitnesService, string? dataSourceId = null, string? dataType = null)
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

        protected virtual ListRequest CreateSessionRequest(DateTime start, DateTime end, string activityType)
        {
            return new ListRequest(_fitnessService, "me")
            {
                StartTime = SettingsAndMethodsGoogleApiHelper.ToRfc3339String(start),
                EndTime = SettingsAndMethodsGoogleApiHelper.ToRfc3339String(end),
                ActivityType = activityType
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

            return aggregate.ExecuteAsync(_cancellationToken);
        }

        protected virtual ListSessionsResponse ExecuteSessionRequest(DateTime start, DateTime end, string activityType)
        {
            var listSession = CreateSessionRequest(start, end, activityType);

            return listSession.Execute();
        }
    }
}
