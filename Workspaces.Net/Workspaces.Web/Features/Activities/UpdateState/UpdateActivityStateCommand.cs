using FluentResults;
using MediatR;

namespace Workspaces.Net.Web.Features.Activities.UpdateState
{
    public record UpdateActivityStateCommand(Guid Id, string? Title, string? Content, bool IsCompleted) : IRequest<Result<Unit>>;
}