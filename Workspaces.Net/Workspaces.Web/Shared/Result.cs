namespace Workspaces.Net.Web.Shared
{
    public sealed class Result<TResult>
    {
        public bool IsSuccess { get; init; }

        public TResult Value { get; init; }

        public Error Error { get; init; }

        private Result(bool isSuccess, TResult value, Error error)
        {
            this.IsSuccess = isSuccess;
            this.Value = value;
            this.Error = error;
        }

        public static Result<TResult> Ok(TResult value)
        {
            return new Result<TResult>(true, value, Error.None);
        }

        public static Result<TResult> Fail(Error error)
        {
            return new Result<TResult>(false,default,error);
        }
    }
}
