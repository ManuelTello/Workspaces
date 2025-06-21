using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Features.Activities.Create;
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
        public async Task TearDown()
        {
            await this._context.DisposeAsync();
        }

        [Test]
        public async Task CreateActivityHandler_NewEmptyTask_NewTaskWithCurrentDate()
        {
            var handler = new CreateActivityCommandHandler(this._context);
            var result = await handler.Handle(this._command,CancellationToken.None);
            var dbResult = await this._context.Activities.SingleOrDefaultAsync(x => x.Id == result.Id);
            Assert.That(dbResult, Is.Not.Null);
        }
    }
}