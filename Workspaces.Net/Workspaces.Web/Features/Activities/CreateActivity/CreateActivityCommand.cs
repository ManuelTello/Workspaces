using MediatR;

namespace Workspaces.Net.Web.Features.Activities.CreateActivity
{
    public record CreateActivityCommand(string Title, string Content, DateTime DateCreated):IRequest<CreateActivityCommandResponse>;
}