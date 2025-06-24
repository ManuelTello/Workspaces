using Workspaces.Net.Web.Features.Activities.Create;
using Workspaces.Net.Web.Infrastructure.Context;

namespace Workspaces.Net.Tests.Handlers
{
    [TestFixture]
    public class CreateActivityHandlerTest
    {
        private CreateActivityCommand _command;
        
        private CreateActivityCommandHandler _handler;
        
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            this._context = SharedServices.TestDatabase.CreateTestDatabaseContext();
            this._handler = new CreateActivityCommandHandler(this._context);
            this._command = new CreateActivityCommand("Test activity", "Some random content", DateTime.Now);
        }

        [TearDown]
        public async Task TearDown()
        {
            await this._context.DisposeAsync();
        }

        [Test]
        public async Task CreateActivityHandler_NewEmptyTask_NewTaskWithCurrentDate()
        {
            var result = await this._handler.Handle(this._command, CancellationToken.None);
            Assert.That(result.IsSuccess, Is.True,"Operation return failed.");
        }
    }
}