using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(e => e.ExerciseId);

            builder.Property(e => e.ExerciseId)
                .HasColumnName("ExerciseId")
                .IsRequired(true);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Title)
                .HasMaxLength(64)
                .IsRequired(true);
        }
    }
}
