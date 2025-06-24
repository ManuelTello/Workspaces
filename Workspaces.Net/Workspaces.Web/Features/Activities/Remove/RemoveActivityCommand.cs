using FluentResults;
using MediatR;

namespace Workspaces.Net.Web.Features.Activities.Remove
{
    public record RemoveActivityCommand(Guid Id) : IRequest<Result<Unit>>;
}