using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(e => e.GroupId);

            builder.Property(e => e.GroupId)
                .HasColumnName("GroupId")
                .IsRequired(true);

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(e => e.SubjectId)
                .HasColumnName("SubjectId")
                .IsRequired(true);

            builder.HasOne(e => e.Subject)
                .WithMany(e => e.Groups)
                .HasConstraintName("FK_Groups_Subjects");
        }
    }
}
