using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Workspaces.Net.Web.Features.Activities.Create
{
    public class CreateActivityController:ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/activities", async ([FromBody]CreateActivityContract contract, IMediator mediator) =>
            {
                CreateActivityCommand command = new CreateActivityCommand(contract.Title, contract.Content, contract.DateCreated);
                CreateActivityCommandResponse result = await mediator.Send(command);
            });
        }
    }
}