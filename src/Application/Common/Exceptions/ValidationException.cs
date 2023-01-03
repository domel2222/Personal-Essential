
using Domain.Shared;
using ApplicationException = Domain.Exceptions.ApplicationException;

namespace Application.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        
        public IEnumerable<Error> Errors { get; }
        public ValidationException(IEnumerable<Error> errorsCollection)
            : base("Validation Faliure", "One or more validation errors occured")
            => Errors = errorsCollection;

    }
}
