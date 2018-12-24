using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        // TODO GroupConfiguration
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            
        }
    }
}
