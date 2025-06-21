namespace Workspaces.Net.Web.Shared
{
    public sealed class Result<T>
    {
        public bool IsSuccess { get; init; }
        
        public T Value { get; init; }
        
        public Error Error { get; init; }

        private Result(bool isSuccess, T value, Error error)
        {
           this.IsSuccess = isSuccess;
           this.Value = value;
           this.Error = error;
        }

        public static Result<T> Ok(T value)
        {
            throw new NotImplementedException(); 
        }

        public static Result<T> Fail(Error error)
        {
            throw new NotImplementedException(); 
        }
    }
}