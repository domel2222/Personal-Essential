
namespace Application.Common.Behaviours
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation($"Personal Essensial Request: {requestName} {request} {DateTime.Now}");

            return Task.CompletedTask;
        }
    }
}
