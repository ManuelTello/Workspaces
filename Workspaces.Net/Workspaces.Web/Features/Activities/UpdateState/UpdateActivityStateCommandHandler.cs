using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Infrastructure.Context;
using Workspaces.Net.Web.Infrastructure.Models;

namespace Workspaces.Net.Web.Features.Activities.UpdateState
{
    public class UpdateActivityStateCommandHandler : IRequestHandler<UpdateActivityStateCommand, Result<Unit>>
    {
        private readonly ApplicationDbContext _context;

        public UpdateActivityStateCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Result<Unit>> Handle(UpdateActivityStateCommand request, CancellationToken cancellationToken)
        {
            Activity? activity = await this._context.Activities.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            Result<Unit> result;

            if (activity == null)
            {
                result = Result.Fail(Errors.ActivityErrors.ActivityNotFound);
            }
            else
            {
                if (request.Title != null)
                    activity.Title = request.Title;
                if (request.Content != null)
                    activity.Content = request.Content;

                activity.IsCompleted = request.IsCompleted;
                this._context.Activities.Update(activity);
                await this._context.SaveChangesAsync(cancellationToken);
                result = Result.Ok(Unit.Value);
            }

            return result;
        }
    }
}