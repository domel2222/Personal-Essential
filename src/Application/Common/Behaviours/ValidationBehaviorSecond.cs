using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Application.Common.Behaviours
{
    public class ValidationBehaviorSecond<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviorSecond(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                                    .Select(validator => validator.Validate(context))
                                    .SelectMany(validationResult => validationResult.Errors)
                                    .Where(validationFailure => validationFailure != null)
                                    .Select(failure
                                        => new Error(
                                        failure.PropertyName,
                                        failure.ErrorMessage))
                                    .Distinct()
                                    .ToList();

            if (failures.Any())
            {
                throw new ValidationException(
                    failures);
            }

            return await next();
        }
    }
}