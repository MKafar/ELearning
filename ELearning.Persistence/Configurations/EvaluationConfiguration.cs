using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        // TODO EvaluationConfiguration
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.Property(e => e.AssignmentId)
                .HasColumnName("AssignmentId")
                .IsRequired(true);

            builder.Property(e => e.EvaluationId)
                .HasColumnName("EvaluationId")
                .IsRequired(true);

 

            builder.HasOne(e => e.Assignment)
                .WithMany(e => e.Evaluations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Evaluations_Assignments");

            builder.HasOne(e => e.Section)
                .WithMany(e => e.Evaluations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Evaluations_Sections");
        }
    }
}
