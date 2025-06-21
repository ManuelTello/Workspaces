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

        private UpdateCompletedStateCommandHandler _handler;

        private UpdateCompletedStateCommand _command;

        [SetUp]
        public async Task SetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            this._context = new ApplicationDbContext(optionsBuilder);
            this._handler = new UpdateCompletedStateCommandHandler(this._context);
            this._activity = new Activity()
            {
                Id = Guid.NewGuid(),
                Title = "Test activity",
                Content = string.Empty,
                DateCreated = DateTime.Now,
                IsCompleted = false
            };
            this._command = new UpdateCompletedStateCommand(this._activity.Id);
            
            await this._context.Activities.AddAsync(this._activity);
            await this._context.SaveChangesAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await this._context.DisposeAsync();
        }

        [Test]
        public async Task UpdateActivityIsCompletedState_ActivityInFalseState_TheActivityCompleteTrueState()
        {
            var result = await this._handler.Handle(this._command, CancellationToken.None);
            Assert.That(result.IsSuccess, Is.True,$"The update operation could not be completed");
            var activityUpdated = await this._context.Activities.SingleAsync(a => a.Id == this._activity.Id);
            Assert.That(activityUpdated.IsCompleted, Is.True,"The 'is_completed' field is incorrect.");
        }
    }
}