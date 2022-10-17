using System.Collections.Generic;
using ApplicationException = Domain.Exceptions.ApplicationException;

namespace Application.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionery)
            : base("Validation Faliure", "One or more validation errors occured")
            => ErrorsDictionary = errorsDictionery;

    }
}
