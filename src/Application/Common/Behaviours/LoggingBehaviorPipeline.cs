//using Domain.Shared;

//namespace Application.Common.Behaviours
//{
//    public class LoggingBehaviorPipeline<TRequest, TResponse>
//        : IPipelineBehavior<TRequest, TResponse>
//        where TRequest : IRequest<TResponse>
//        where TResponse : Error
//    {
//        private readonly ILogger<LoggingBehaviorPipeline<TRequest, TResponse>> _logger;
//        public async Task<TResponse> Handle(
//            TRequest request, 
//            CancellationToken cancellationToken, 
//            RequestHandlerDelegate<TResponse> next)
//        {

//            _logger.LogInformation($"Starting request {typeof(TRequest).Name}, {DateTime.Now}");
            
//            var result = await next();

//            _logger.LogInformation($"Compleated request {typeof(TRequest).Name}, {DateTime.Now}");

//            return result;
//        }
//    }
//}
