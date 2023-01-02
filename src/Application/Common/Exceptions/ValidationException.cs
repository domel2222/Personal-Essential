
using ApplicationException = Domain.Exceptions.ApplicationException;

namespace Application.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        private object[] _failures;

        public IReadOnlyCollection<string[]> Errors { get; }
        public ValidationException(IReadOnlyCollection<string[]> errorsCollection)
            : base("Validation Faliure", "One or more validation errors occured")
            => Errors = errorsCollection;

    }
}
