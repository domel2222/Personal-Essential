namespace Domain.Exceptions
{
    public class ForbiddenException : ApplicationException
    {
        public ForbiddenException(string message) : base("Forrbidden Exception", message)
        {
        }
    }
}