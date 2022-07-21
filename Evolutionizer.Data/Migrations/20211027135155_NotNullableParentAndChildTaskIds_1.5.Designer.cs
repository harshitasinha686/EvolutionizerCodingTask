﻿// <auto-generated />
using System;
using Evolutionizer.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Evolutionizer.Data.Migrations
{
    [DbContext(typeof(EvolutionizerCodingTaskDbContext))]
    [Migration("20211027135155_NotNullableParentAndChildTaskIds_1.5")]
    partial class NotNullableParentAndChildTaskIds_15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.TaskDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChildTaskId")
                        .HasColumnType("int");

                    b.Property<int>("ParentTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildTaskId");

                    b.HasIndex("ParentTaskId");

                    b.ToTable("TaskDependency");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Project", b =>
                {
                    b.HasOne("Evolutionizer.BusinessLayer.Entities.Program", "Program")
                        .WithMany("Projects")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Task", b =>
                {
                    b.HasOne("Evolutionizer.BusinessLayer.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.TaskDependency", b =>
                {
                    b.HasOne("Evolutionizer.BusinessLayer.Entities.Task", "ChildTask")
                        .WithMany("ParentTask")
                        .HasForeignKey("ChildTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Evolutionizer.BusinessLayer.Entities.Task", "ParentTask")
                        .WithMany("ChildTask")
                        .HasForeignKey("ParentTaskId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("ChildTask");

                    b.Navigation("ParentTask");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Program", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Evolutionizer.BusinessLayer.Entities.Task", b =>
                {
                    b.Navigation("ChildTask");

                    b.Navigation("ParentTask");
                });
#pragma warning restore 612, 618
        }
    }
}
