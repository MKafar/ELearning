﻿// <auto-generated />
using System;
using ELearning.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELearning.Persistence.Migrations
{
    [DbContext(typeof(ELearningDbContext))]
    partial class ELearningDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELearning.Domain.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AssignmentId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("FinalGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(4, 2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnName("SectionId");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskVariantId")
                        .HasColumnName("TaskVariantId");

                    b.HasKey("AssignmentId");

                    b.HasIndex("SectionId");

                    b.HasIndex("TaskVariantId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Evaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EvaluationId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId")
                        .HasColumnName("AssignmentId");

                    b.Property<decimal>("Grade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(4, 2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("SectionId")
                        .HasColumnName("SectionId");

                    b.HasKey("EvaluationId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("SectionId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GroupId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AcademicYear")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("SubjectId")
                        .HasColumnName("SubjectId");

                    b.HasKey("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SectionId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupId");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.Property<int>("UserId")
                        .HasColumnName("UserId");

                    b.HasKey("SectionId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubjectId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TaskId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.TaskVariant", b =>
                {
                    b.Property<int>("TaskVariantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TaskVariantId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectOutput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.Property<int>("TaskId")
                        .HasColumnName("TaskId");

                    b.Property<string>("TestingCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskVariantId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskVariants");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleId");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("ELearning.Domain.Entities.Section", "Section")
                        .WithMany("Assignments")
                        .HasForeignKey("SectionId")
                        .HasConstraintName("FK_Assignments_Sections")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELearning.Domain.Entities.TaskVariant", "TaskVariant")
                        .WithMany("Assignments")
                        .HasForeignKey("TaskVariantId")
                        .HasConstraintName("FK_Assignments_TaskVariants")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Evaluation", b =>
                {
                    b.HasOne("ELearning.Domain.Entities.Assignment", "Assignment")
                        .WithMany("EvaluationsReceived")
                        .HasForeignKey("AssignmentId")
                        .HasConstraintName("FK_EvaluationsReceived_Assignments")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ELearning.Domain.Entities.Assignment", "Section")
                        .WithMany("EvaluationsGiven")
                        .HasForeignKey("SectionId")
                        .HasConstraintName("FK_EvaluationsGiven_Assignments")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Group", b =>
                {
                    b.HasOne("ELearning.Domain.Entities.Subject", "Subject")
                        .WithMany("Groups")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Groups_Subjects")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELearning.Domain.Entities.Section", b =>
                {
                    b.HasOne("ELearning.Domain.Entities.Group", "Group")
                        .WithMany("Sections")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Sections_Groups")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELearning.Domain.Entities.User", "User")
                        .WithMany("Sections")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Sections_Users")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELearning.Domain.Entities.TaskVariant", b =>
                {
                    b.HasOne("ELearning.Domain.Entities.Task", "Task")
                        .WithMany("TaskVariants")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("FK_TaskVariants_Tasks")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELearning.Domain.Entities.User", b =>
                {
                    b.HasOne("ELearning.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Users_Roles")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
