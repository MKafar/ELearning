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

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Variant> Variants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ELearningDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
