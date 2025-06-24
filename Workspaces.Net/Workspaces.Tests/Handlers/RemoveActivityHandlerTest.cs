using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Features.Activities.Remove;
using Workspaces.Net.Web.Infrastructure.Context;
using Workspaces.Net.Web.Infrastructure.Models;

namespace Workspaces.Net.Tests.Handlers
{
    [TestFixture]
    public class RemoveActivityHandlerTest
    {
        private Activity _activity;

        private RemoveActivityCommand _command;

        private RemoveActivityCommandHandler _handler;

        private ApplicationDbContext _context;
        
        [SetUp]
        public void SetUp()
        {
            this._context = SharedServices.TestDatabase.CreateTestDatabaseContext();
            this._activity = new Activity()
            {
                Id = Guid.NewGuid(),
                Title = string.Empty,
                Content = string.Empty,
                IsCompleted = false,
                DateCreated = DateTime.Now
            };
            this._command = new RemoveActivityCommand(this._activity.Id);
            this._handler = new RemoveActivityCommandHandler(this._context); 
        }

        [TearDown]
        public async Task TearDown()
        {
           await this._context.DisposeAsync(); 
        }

        [Test]
        public async Task RemoveActivityHandler_NewlyCreatedActivity_RemovedActivity()
        {
            await this._context.AddAsync(this._activity);
            await this._context.SaveChangesAsync();
            var result = await this._handler.Handle(this._command,CancellationToken.None);
            Assert.That(result.IsSuccess, Is.True, "Handler failed.");
            var searchActivity = await this._context.Activities.SingleOrDefaultAsync(a => a.Id == this._activity.Id);
            Assert.That(searchActivity, Is.Null, "Activity was not removed.");
        }
    }
}