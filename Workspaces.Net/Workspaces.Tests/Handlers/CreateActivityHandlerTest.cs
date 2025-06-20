using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Features.Activities.CreateActivity;
using Workspaces.Net.Web.Infrastructure.Context;

namespace Workspaces.Net.Tests.Handlers
{
    [TestFixture]
    public class CreateActivityHandlerTest
    {
        private ApplicationDbContext _context;

        private CreateActivityCommand _command;
        
        
        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            this._context = new ApplicationDbContext(optionsBuilder);
            this._command = new CreateActivityCommand("Test activity","Some random content",DateTime.Now);
        }

        [TearDown]
        public void TearDown()
        {
            this._context.Dispose();
        }

        [Test]
        public async Task CreateActivityHandler_NewEmptyTask_NewTaskWithCurrentDate()
        {
            var handler = new CreateActivityCommandHandler(this._context);
            var result = await handler.Handle(this._command,CancellationToken.None);
            Assert.That(result.DateCreated, Is.EqualTo(this._command.DateCreated));
        }
    }
}