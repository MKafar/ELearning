using Microsoft.EntityFrameworkCore;
using ELearning.Domain.Entities;

namespace ELearning.Persistence
{
    public class ELearningDbContext : DbContext
    {
        public ELearningDbContext(DbContextOptions<ELearningDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskVariant> TaskVariants { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ELearningDbContext).Assembly);
        }
    }
}
