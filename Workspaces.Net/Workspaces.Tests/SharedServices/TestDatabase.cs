using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Infrastructure.Context;

namespace Workspaces.Net.Tests.SharedServices
{
    public class TestDatabase
    {
        public static ApplicationDbContext CreateTestDatabaseContext()
        {
           DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            ApplicationDbContext context = new  ApplicationDbContext(options);
            bool isCreated = context.Database.EnsureCreated();
            if(!isCreated)
                throw new Exception("Database creation failed.");

            return context;
        }
    }
}