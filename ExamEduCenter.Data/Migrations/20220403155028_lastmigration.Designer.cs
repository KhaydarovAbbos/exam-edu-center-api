﻿// <auto-generated />
using System;
using ExamEduCenter.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ExamEduCenter.Data.Migrations
{
    [DbContext(typeof(EduCenterDbContext))]
    [Migration("20220403155028_lastmigration")]
    partial class lastmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ExamEduCenter.Domain.Entities.Courses.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<long>("CourseTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("WievCount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseTypeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ExamEduCenter.Domain.Entities.Courses.CourseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("CourseTypes");
                });

            modelBuilder.Entity("ExamEduCenter.Domain.Entities.Courses.Course", b =>
                {
                    b.HasOne("ExamEduCenter.Domain.Entities.Courses.CourseType", "CourseType")
                        .WithMany()
                        .HasForeignKey("CourseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseType");
                });
#pragma warning restore 612, 618
        }
    }
}
