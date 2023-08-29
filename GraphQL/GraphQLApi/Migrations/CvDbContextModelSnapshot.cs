﻿// <auto-generated />
using System;
using GraphQLApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLApi.Migrations
{
    [DbContext(typeof(CvDbContext))]
    partial class CvDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("GraphQLApi.DTOs.CompanyDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CvDTOId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvDTOId");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("GraphQLApi.DTOs.CvDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cvs", (string)null);
                });

            modelBuilder.Entity("GraphQLApi.DTOs.EducationDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CvDTOId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvDTOId");

                    b.ToTable("Educations", (string)null);
                });

            modelBuilder.Entity("GraphQLApi.DTOs.ProjectDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CvDTOId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvDTOId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("GraphQLApi.DTOs.SkillDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CvDTOId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvDTOId");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("GraphQLApi.DTOs.CompanyDTO", b =>
                {
                    b.HasOne("GraphQLApi.DTOs.CvDTO", null)
                        .WithMany("CompanyDTOs")
                        .HasForeignKey("CvDTOId");
                });

            modelBuilder.Entity("GraphQLApi.DTOs.EducationDTO", b =>
                {
                    b.HasOne("GraphQLApi.DTOs.CvDTO", null)
                        .WithMany("EducationDTOs")
                        .HasForeignKey("CvDTOId");
                });

            modelBuilder.Entity("GraphQLApi.DTOs.ProjectDTO", b =>
                {
                    b.HasOne("GraphQLApi.DTOs.CvDTO", null)
                        .WithMany("ProjectDtos")
                        .HasForeignKey("CvDTOId");
                });

            modelBuilder.Entity("GraphQLApi.DTOs.SkillDTO", b =>
                {
                    b.HasOne("GraphQLApi.DTOs.CvDTO", null)
                        .WithMany("SkillDtos")
                        .HasForeignKey("CvDTOId");
                });

            modelBuilder.Entity("GraphQLApi.DTOs.CvDTO", b =>
                {
                    b.Navigation("CompanyDTOs");

                    b.Navigation("EducationDTOs");

                    b.Navigation("ProjectDtos");

                    b.Navigation("SkillDtos");
                });
#pragma warning restore 612, 618
        }
    }
}
