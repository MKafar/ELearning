using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        //TODO SectionConfiguration
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            
        }
    }
}
