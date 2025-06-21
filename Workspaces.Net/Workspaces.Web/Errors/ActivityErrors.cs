using Workspaces.Net.Web.ErrorType;

namespace Workspaces.Net.Web.Errors
{
    public static class ActivityErrors
    {
        public static readonly SingleError UpdateActivityCompletedStateNotFound = new SingleError("Features.Activities.UpdateCompletedState", "ActivityErrors not found.");
    }
}