namespace Workspaces.Net.Web.Features.Activities.CreateActivity
{
    public record CreateActivityCommandResponse(Guid Id, string Title, string Content, DateTime DateCreated);
}