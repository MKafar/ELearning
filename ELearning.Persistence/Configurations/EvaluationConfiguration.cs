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
            builder.HasOne(e => e.Assignment)
                .WithMany(e => e.Evaluations)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Section)
                .WithMany(e => e.Evaluations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
