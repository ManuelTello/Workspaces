using Workspaces.Net.Web.Shared;

namespace Workspaces.Net.Web.ErrorType
{
    public class SingleError:Error
    {
        public string Message { get; init; }

        public SingleError(string origin, string message)
        {
            this.Origin = origin;
            this.Message = message;
        }
    }
}