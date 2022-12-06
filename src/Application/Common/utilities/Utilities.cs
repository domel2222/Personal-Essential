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
    }
}