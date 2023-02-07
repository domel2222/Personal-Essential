namespace Domain.Shared
{
    public class Result<T>
    {
        public bool Success { get;}
        public T Value { get; }

        public IEnumerable<Error> Errors { get; set; }

        public Result(bool success, T value, IEnumerable<Error> error) 
        {  
            Success = success; 
            Value = value;
            Errors = error;
        }

        public static Result<T>Succeed(T value)
        {
            return new Result<T>(true, value, null);
        }

        public static Result<T>Fail(IEnumerable<Error> error)
        {
            return new Result<T>(false, default(T), error);
        }
    }
}
