using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class TaskVariantConfiguration : IEntityTypeConfiguration<TaskVariant>
    {
        // TODO TaskVariantConfiguration
        public void Configure(EntityTypeBuilder<TaskVariant> builder)
        {
            
        }
    }
}
