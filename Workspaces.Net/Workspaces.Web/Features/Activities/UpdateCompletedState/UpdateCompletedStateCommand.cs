using MediatR;
using Workspaces.Net.Web.Shared;

namespace Workspaces.Net.Web.Features.Activities.UpdateCompletedState
{
    public record UpdateCompletedStateCommand(Guid Id):IRequest<Result<Unit>>;
}