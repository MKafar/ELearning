﻿using ELearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearning.Persistence.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasOne(e => e.Assignment)
                .WithMany(e => e.Evaluations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Evaluations_Assignments");

            builder.Property(e => e.AssignmentId)
                .HasColumnName("AssignmentId")
                .IsRequired(true);

            builder.HasKey(e => e.EvaluationId);

            builder.Property(e => e.EvaluationId)
                .HasColumnName("EvaluationId")
                .IsRequired(true);

            builder.Property(e => e.Grade)
                .HasColumnType("decimal(4, 2)")
                .HasDefaultValue(0);

            builder.HasOne(e => e.Section)
                .WithMany(e => e.Evaluations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Evaluations_Sections");

            builder.Property(e => e.SectionId)
                .HasColumnName("SectionId")
                .IsRequired(true);
        }
    }
}
