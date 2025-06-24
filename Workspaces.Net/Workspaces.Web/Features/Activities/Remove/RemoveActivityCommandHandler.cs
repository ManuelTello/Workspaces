using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Infrastructure.Context;
using Workspaces.Net.Web.Infrastructure.Models;

namespace Workspaces.Net.Web.Features.Activities.Remove
{
    public class RemoveActivityCommandHandler:IRequestHandler<RemoveActivityCommand, Result<Unit>>
    {
        private readonly ApplicationDbContext _context;

        public RemoveActivityCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public async Task<Result<Unit>> Handle(RemoveActivityCommand request, CancellationToken cancellationToken)
        {
            Result<Unit> result;
            Activity? activity = await this._context.Activities.SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (activity == null)
            {
                result = Result.Fail(Errors.ActivityErrors.ActivityNotFound);
            }
            else
            {
               this._context.Activities.Remove(activity);
               await this._context.SaveChangesAsync(cancellationToken);
               result = Result.Ok<Unit>(Unit.Value);
            }

            return result;
        }
    }
}