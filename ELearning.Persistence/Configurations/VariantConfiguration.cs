using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.HasKey(e => e.VariantId);

            builder.Property(e => e.VariantId)
                .HasColumnName("VariantId")
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

            builder.Property(e => e.ExerciseId)
                .HasColumnName("ExerciseId")
                .IsRequired(true);

            builder.Property(e => e.TestingCode)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.HasOne(e => e.Exercise)
                .WithMany(e => e.Variants)
                .HasConstraintName("FK_Variants_Exercises");
        }
    }
}
