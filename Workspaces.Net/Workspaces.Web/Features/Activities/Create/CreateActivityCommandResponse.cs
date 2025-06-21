namespace Workspaces.Net.Web.Features.Activities.Create
{
    public record CreateActivityCommandResponse(Guid Id, string Title, string Content, DateTime DateCreated);
}