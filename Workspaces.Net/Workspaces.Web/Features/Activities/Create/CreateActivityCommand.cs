using FluentResults;
using MediatR;

namespace Workspaces.Net.Web.Features.Activities.Create
{
    public record CreateActivityCommand(string Title, string Content, DateTime DateCreated) : IRequest<Result<Unit>>;
}