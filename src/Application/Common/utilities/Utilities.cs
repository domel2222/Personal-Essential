namespace Application.Common.Utilities
{
    public static class Utilities
    {
        public static bool CompareDateToLocalTime(this DateTime incomingDate)
        {
            var localTime = DateTime.Now.ToLocalTime();
            var localDateOnly = new DateOnly(localTime.Year, localTime.Month, localTime.Day);
            var incomingDateOnly = new DateOnly(incomingDate.Year, incomingDate.Month, incomingDate.Day);

            return (incomingDateOnly <= localDateOnly);
        }

        public static Result<T> CreateValidationErrorList<T>(ValidationResult validationResult)
        {
            return Result<T>.Fail(validationResult.Errors
                                                        .Where(validationFailure => validationFailure != null)
                                                        .Select(failure =>
                                                        new Error(failure.PropertyName, failure.ErrorMessage))
                                                        .Distinct()
                                                        .ToList());
        }
    }
}