using Carter;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Workspaces.Net.Web.Features.Activities.Create
{
    public class CreateActivityModule:ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/activity", async ([FromBody]  CreateActivityContract contract, IMediator mediator) =>
            {
                CreateActivityCommand command = new CreateActivityCommand(contract.Title, contract.Content, contract.DateCreated);
                Result<Unit> result = await mediator.Send(command);
            });
        }
    }
}