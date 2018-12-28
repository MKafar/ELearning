using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(e => e.SubjectId);

            builder.Property(e => e.SubjectId)
                .HasColumnName("SubjectId")
                .IsRequired(true);

            builder.Property(e => e.Abreviation)
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired(true);
        }
    }
}
