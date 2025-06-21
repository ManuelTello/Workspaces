using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Features.Activities.UpdateCompletedState;
using Workspaces.Net.Web.Infrastructure.Context;
using Workspaces.Net.Web.Infrastructure.Models;

namespace Workspaces.Net.Tests.Handlers
{
    [TestFixture]
    public class UpdateActivityIsCompletedStateTest
    {
        private ApplicationDbContext _context;

        private Activity _activity;

        private UpdateCompletedStateCommand _command;

        [SetUp]
        public void SetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            this._context = new ApplicationDbContext(optionsBuilder);
            this._activity = new Activity()
            {
                Id = Guid.NewGuid(),
                Title = "Test activity",
                Content = string.Empty,
                DateCreated = DateTime.Now,
                IsCompleted = false
            };
            this._command = new UpdateCompletedStateCommand(this._activity.Id);
        }

        [TearDown]
        public async Task TearDown()
        {
            await this._context.DisposeAsync();
        }

        [Test]
        public async Task UpdateActivityIsCompletedState_ActivityInFalseState_TheActivityInTrueState()
        {
            await this._context.Activities.AddAsync(this._activity);
            await this._context.SaveChangesAsync();
            var handler = new UpdateCompletedStateCommandHandler(this._context);
            await handler.Handle(this._command, CancellationToken.None);
            
        }
    }
}