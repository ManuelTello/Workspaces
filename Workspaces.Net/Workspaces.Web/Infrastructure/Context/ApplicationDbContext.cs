using Microsoft.EntityFrameworkCore;
using Workspaces.Net.Web.Infrastructure.Models;

namespace Workspaces.Net.Web.Infrastructure.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Activity> Activities { get; set; } 
        
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}