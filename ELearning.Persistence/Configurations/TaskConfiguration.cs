using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(e => e.TaskId);

            builder.Property(e => e.TaskId)
                .HasColumnName("TaskId")
                .IsRequired(true);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Title)
                .HasMaxLength(64)
                .IsRequired(true);
        }
    }
}
