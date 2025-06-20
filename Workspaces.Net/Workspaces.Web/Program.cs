using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationConnection") ?? throw new NullReferenceException();
var assembly = typeof(Program).Assembly;

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(assembly));
builder.Services.AddCarter();
builder.Services.AddValidatorsFromAssembly(assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapCarter();
app.UseHttpsRedirection();
app.Run();