using CognizantChallenge.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CognizantChallenge.Core.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
                .HasOne<Task>(c => c.Task)
                .WithMany(t => t.Challenges)
                .HasForeignKey(c => c.TaskId);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
    }
   

}
