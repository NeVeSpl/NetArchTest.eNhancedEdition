using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SampleApp.ModuleOmega.Domain.Questions;

namespace SampleApp.ModuleOmega.Persistence
{
    internal class TestCreationDbContext : DbContext
    {
        public DbSet<Question> Questions { get; protected set; }


        public TestCreationDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
        }
    }
}
