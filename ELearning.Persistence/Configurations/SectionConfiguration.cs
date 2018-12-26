﻿using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasOne(e => e.Group)
                .WithMany(e => e.Sections)
                .HasConstraintName("FK_Sections_Groups");

            builder.Property(e => e.GroupId)
                .HasColumnName("GroupId")
                .IsRequired(true);

            builder.Property(e => e.Number)
                .HasColumnType("smallint");

            builder.HasKey(e => e.SectionId);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Sections)
                .HasConstraintName("FK_Groups_Users");

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .IsRequired(true);
        }
    }
}
