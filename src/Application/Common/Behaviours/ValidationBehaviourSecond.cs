using Domain.Shared;
using System.Collections.Generic;
using ValidationException = Application.Common.Exceptions.ValidationException;
namespace Application.Common.Behaviours
{
    public class ValidationBehaviourSecond<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : class, ICommand<TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviourSecond(IEnumerable<IValidator<TRequest>> validators)
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

            //var failures = _validators.Select(v => v.Validate(context))
            //                                             .SelectMany(result => result.Errors)
            //                                             .Where(f => f != null).ToList();

            var failures = _validators
                                    .Select(validator => validator.Validate(context))
                                    .SelectMany(validationResult => validationResult.Errors)
                                    .Where(validationFailure => validationFailure != null)
                                    .Select(failure => new Error(
                                    
                                        failure.PropertyName,
                                        failure.ErrorMessage)
                                    )
                                    .Distinct()
                                     .ToArray();

            var listOfFailures = new List<string[]>();
            foreach (var error in failures)
            {
                listOfFailures.Add(new string[] { error.Code, error.Message });
            }

            if (failures.Any())
            //{
            //    throw new ValidationException(failures);
            //}
            {
                throw new ValidationException(
                    listOfFailures);
            }
        

            return await next();
        }
    }
}