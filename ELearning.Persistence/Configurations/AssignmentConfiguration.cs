using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        // TODO AssignmentConfiguration
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            
        }
    }
}
