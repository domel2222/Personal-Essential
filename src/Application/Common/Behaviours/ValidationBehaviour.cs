using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //where TRequest : class, ICommand<TResponse>
    where TRequest : class, MediatR.IRequest<TResponse>
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

            var faliures = _validators.Select(x => x.Validate(context))
                                                              .SelectMany(result => result.Errors)
                                                              .Where(f => f != null)
                                                              .ToList();
            //var errorsDictionaray = _validators
            //                                    .Select(x => x.Validate(context))
            //                                    .SelectMany(x => x.Errors)
            //                                    .Where(x => x != null)
            //                                    .GroupBy(
            //                        x => x.PropertyName,
            //                                      x => x.ErrorMessage,
            //                                      (propertyName, errorMessages) =>                      new
            //                                      {
            //                                          Key = propertyName,
            //                                          Values = errorMessages.Distinct().ToArray()

            //                                      })
            //                                      .ToDictionary(x => x.Key, x => x.Values);


            if (faliures.Any())
            {
                throw new ValidationException(faliures);
            }
            return await next();
        }
    }
    //public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //{
    //    private readonly IEnumerable<IValidator<TRequest>> _validators;

    //    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    //    {
    //        _validators = validators;
    //    }
    //    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    {
    //        if (_validators.Any())
    //        {
    //            var context = new ValidationContext<TRequest>(request);

    //            var failures = _validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(f => f != null).ToList();

    //            if (failures.Count != 0)
    //            {
    //                throw new ValidationException(failures);
    //            }
    //        }
    //        return await next();
    //    }
    //}
}
