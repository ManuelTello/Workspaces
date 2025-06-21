using MediatR;
using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Infrastructure.Context;
using Workspaces.Net.Web.Infrastructure.Models;
using Workspaces.Net.Web.Shared;

namespace Workspaces.Net.Web.Features.Activities.UpdateCompletedState
{
    public class UpdateCompletedStateCommandHandler:IRequestHandler<UpdateCompletedStateCommand, Result<Unit>>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCompletedStateCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public async Task<Result<Unit>> Handle(UpdateCompletedStateCommand request, CancellationToken cancellationToken)
        {
            Activity? activity = await this._context.Activities.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (activity == null)
            {
                Result<Unit> result = Result<Unit>.Fail(Errors.ActivityErrors.UpdateActivityCompletedStateNotFound);
                return result;
            }
            else
            {
                await this._context.Activities.Where(x => x.Id == request.Id)
                    .ExecuteUpdateAsync(x => 
                        x.SetProperty(p => p.IsCompleted, !activity.IsCompleted), cancellationToken);
                Result<Unit> result = Result<Unit>.Ok(Unit.Value);
                return result;
            }
        }
    }
}