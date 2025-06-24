using FluentResults;
using MediatR;

namespace Workspaces.Net.Web.Features.Activities.UpdateStateInformation
{
    public record UpdateStateInformationCommand(Guid Id, string? Title, string? Content, bool IsCompleted) : IRequest<Result<Unit>>;
}