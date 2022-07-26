
namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class GoogleTimeHelper
    {
        private static readonly DateTime zero = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public long TotalMilliseconds { get; private set; }

        private GoogleTimeHelper()
        {

        }

        public static GoogleTimeHelper FromDateTime(DateTime datetime)
        {
            if (datetime < zero)
            {
                throw new Exception("Invalid Google datetime");
            }

            return new GoogleTimeHelper()
            {
                TotalMilliseconds = (long)(datetime - zero).TotalMilliseconds
            };
        }

        public static GoogleTimeHelper FromNanoseconds(long? nanoseconds)
        {
            if (nanoseconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nanoseconds), "Must be greater than 0");
            }

            return new GoogleTimeHelper()
            {
                TotalMilliseconds = (long)(nanoseconds.GetValueOrDefault(0) / 1000000)
            };
        }

        public static GoogleTimeHelper FromMiliseconds(long? miliseconds)
        {
            if (miliseconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(miliseconds), "Must be greater than 0");
            }

            return new GoogleTimeHelper()
            {
                TotalMilliseconds = (long)(miliseconds.GetValueOrDefault(0))
            };
        }

        public static GoogleTimeHelper Now => FromDateTime(DateTime.Now);

        public GoogleTimeHelper Add(TimeSpan timeSpan)
        {
            return new GoogleTimeHelper()
            {
                TotalMilliseconds = this.TotalMilliseconds + (long)timeSpan.TotalMilliseconds
            };
        }

        public DateTime ToDateTime()
        {
            return zero.AddMilliseconds(this.TotalMilliseconds);
        }
    }
}
