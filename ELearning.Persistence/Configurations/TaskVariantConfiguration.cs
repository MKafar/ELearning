using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class TaskVariantConfiguration : IEntityTypeConfiguration<TaskVariant>
    {
        public void Configure(EntityTypeBuilder<TaskVariant> builder)
        {
            builder.HasKey(e => e.TaskVariantId);

            builder.Property(e => e.TaskVariantId)
                .HasColumnName("TaskVariantId")
                .IsRequired(true);

            builder.Property(e => e.Content)
                .HasColumnType("nvarchar(max)")
                .IsRequired(true);

            builder.Property(e => e.CorrectOutput)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(e => e.Number)
                .HasColumnType("tinyint")
                .IsRequired(true);

            builder.Property(e => e.TaskId)
                .HasColumnName("TaskId")
                .IsRequired(true);

            builder.Property(e => e.TestingCode)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.HasOne(e => e.Task)
                .WithMany(e => e.TaskVariants)
                .HasConstraintName("FK_TaskVariants_Tasks");
        }
    }
}
