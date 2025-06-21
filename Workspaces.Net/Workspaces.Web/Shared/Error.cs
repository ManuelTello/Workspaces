namespace Workspaces.Net.Web.Shared
{
    public class Error
    {
        public static readonly Error None = new Error(string.Empty, string.Empty);
        
        public string Origin { get; init; }
        
        public string Message { get; init; }

        public Error(string origin, string message)
        {
            this.Origin = origin;
            this.Message = message;
        }
    }
}