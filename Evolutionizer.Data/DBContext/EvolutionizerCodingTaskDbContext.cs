using Evolutionizer.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Evolutionizer.BusinessLayer.Entities.Task;

namespace Evolutionizer.Data.DBContext
{
    public class EvolutionizerCodingTaskDbContext : DbContext
    {
        public EvolutionizerCodingTaskDbContext(DbContextOptions<EvolutionizerCodingTaskDbContext> options) : base(options)
        {

        }

      
        public DbSet<Program> Programs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many relationships
            modelBuilder.Entity<TaskDependency>()
                .HasOne(x => x.ParentTask)
                .WithMany(y => y.ChildTaskDependency)
                .HasForeignKey(z => z.ParentTaskId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<TaskDependency>()
               .HasOne(x => x.ChildTask)
               .WithMany(y => y.ParentTaskDependency)
               .HasForeignKey(z => z.ChildTaskId);

            //To avoid Concurrency and data loss
            modelBuilder.Entity<Program>()
            .Property(a => a.Description).IsConcurrencyToken();

            modelBuilder.Entity<Project>()
            .Property(a => a.Description).IsConcurrencyToken();

            modelBuilder.Entity<Task>()
            .Property(a => a.Description).IsConcurrencyToken();
        }
    }
}
