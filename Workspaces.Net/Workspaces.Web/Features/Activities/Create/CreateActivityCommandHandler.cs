using FluentResults;
using MediatR;
using Workspaces.Net.Web.Infrastructure.Context;
using Workspaces.Net.Web.Infrastructure.Models;

namespace Workspaces.Net.Web.Features.Activities.Create
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Result<Guid>>
    {
        private readonly ApplicationDbContext _context;

        public CreateActivityCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Result<Guid>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            Result<Guid> result;
            Activity activity = new Activity()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                DateCreated = request.DateCreated
            };

            await this._context.Activities.AddAsync(activity, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);

            result = Result.Ok(activity.Id);
            return result;
        }
    }
}