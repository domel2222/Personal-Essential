using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ValidationException = Application.Common.Exceptions.ValidationException;
using FluentValidation;
using MediatR;
using Application.Abstractions.Messaging;

namespace Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<IRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);


            var errorsDictionaray = _validators
                                                .Select(x => x.Validate(context))
                                                .SelectMany(x => x.Errors)
                                                .Where(x => x != null)
                                                .GroupBy(
                                    x => x.PropertyName,
                                                  x => x.ErrorMessage,
                                                  (propertyName, errorMessages) => new
                                                  {
                                                      Key = propertyName,
                                                      Values = errorMessages.Distinct().ToArray()

                                                  })
                                                  .ToDictionary(x => x.Key, x => x.Values);


            if (errorsDictionaray.Any())
            {
                throw new ValidationException(errorsDictionaray);
            }
            return await next();
        }
    }
}
