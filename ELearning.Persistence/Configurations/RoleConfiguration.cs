using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.RoleId);

            builder.Property(e => e.RoleId)
                .HasColumnName("RoleId")
                .IsRequired(true);

            builder.Property(e => e.Name)
                .HasMaxLength(16)
                .IsRequired(true);
        }
    }
}
