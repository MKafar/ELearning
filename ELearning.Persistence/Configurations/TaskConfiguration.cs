using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        // TODO TaskConfiguration
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            
        }
    }
}
