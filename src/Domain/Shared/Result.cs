namespace Domain.Shared
{
    public class Result<T>
    {
        public bool Success { get; init; }
        public T Value { get; init; }

        //public List<Error> Error{get; set;}
        public string Error { get; }

        public Result(bool success, T value, string error) 
        {  
            
            Success = success; 
            Value = value;
            Error = error;
        }

        public static Result<T>Successful (T value)
        {
            return new Result<T>(true, value, null);
        }

        public static Result<T> Failed(string error)
        {
            return new Result<T>(false, default(T), error);
        }
    }
}
