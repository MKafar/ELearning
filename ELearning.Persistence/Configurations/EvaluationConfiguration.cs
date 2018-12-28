using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(e => e.EvaluationId);

            builder.Property(e => e.EvaluationId)
                .HasColumnName("EvaluationId")
                .IsRequired(true);

            builder.Property(e => e.AssignmentId)
                .HasColumnName("AssignmentId")
                .IsRequired(true);

            builder.Property(e => e.Grade)
                .HasColumnType("decimal(4, 2)")
                .HasDefaultValue((decimal)0)
                .IsRequired(true);

            builder.Property(e => e.SectionId)
                .HasColumnName("SectionId")
                .IsRequired(true);

            builder.HasOne(e => e.Assignment)
                .WithMany(e => e.EvaluationsReceived)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EvaluationsReceived_Assignments");

            builder.HasOne(e => e.Section)
                .WithMany(e => e.EvaluationsGiven)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EvaluationsGiven_Assignments");
        }
    }
}
