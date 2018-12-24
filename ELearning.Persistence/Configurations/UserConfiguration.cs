using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserId).HasColumnName("UserId");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.Surname).HasMaxLength(50);
        }
    }
}
