using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        // TODO SubjectConfiguration
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            
        }
    }
}
