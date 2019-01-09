using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(e => e.AssignmentId);

            builder.Property(e => e.AssignmentId)
                .HasColumnName("AssignmentId")
                .IsRequired(true);

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .IsRequired(true);

            builder.Property(e => e.FinalGrade)
                .HasColumnType("decimal(4, 2)")
                .HasDefaultValue((double)0);

            builder.Property(e => e.Output)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.SectionId)
                .HasColumnName("SectionId")
                .IsRequired(true);

            builder.Property(e => e.Solution)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.VariantId)
                .HasColumnName("VariantId")
                .IsRequired(true);

            builder.HasOne(e => e.Section)
                .WithMany(e => e.Assignments)
                .HasConstraintName("FK_Assignments_Sections");

            builder.HasOne(e => e.Variant)
                .WithMany(e => e.Assignments)
                .HasConstraintName("FK_Assignments_Variants");
        }
    }
}
