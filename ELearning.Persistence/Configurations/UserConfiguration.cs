using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .IsRequired(true);

            builder.Property(e => e.Email)
                .HasMaxLength(320)
                .IsRequired(true);

            builder.Property(e => e.Role)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Login)
                .HasMaxLength(10)
                .IsRequired(true);

            builder.Property(e => e.Password)
                .IsRequired(true);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}
