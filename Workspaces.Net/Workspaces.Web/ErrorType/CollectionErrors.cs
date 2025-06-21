using Workspaces.Net.Web.Shared;

namespace Workspaces.Net.Web.ErrorType
{
    public class CollectionErrors:Error
    {
        public ICollection<string> Errors { get; init; }

        public CollectionErrors(string origin,ICollection<string> collection)
        {
            this.Origin = origin;
            this.Errors = collection;
        }
    }
}