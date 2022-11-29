﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PersonalDbContext))]
    [Migration("20221129102016_InitDataMigration")]
    partial class InitDataMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DiaryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("InactivatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("Domain.Entities.MostWinDuringTheDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("InactivatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StrenghtId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.HasIndex("StrenghtId");

                    b.ToTable("MostWins");
                });

            modelBuilder.Entity("Domain.Entities.SelfAssessmentValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AffirmationResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("AssesmentDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("AudiobookReadingResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("CaloriesResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("DailyResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("DeepWorkResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("EnglishTimeResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid?>("InactivatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LearningResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("StepsResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("TrainingResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("UsePhoneResult")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.HasIndex("UserId");

                    b.ToTable("SelfAssessmentValues");
                });

            modelBuilder.Entity("Domain.Entities.Strenght", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("InactivatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Strenghts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37ad5fb7-0b86-46ec-9608-9cbf5e70d4aa"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5112),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5144),
                            Name = "Responsibility"
                        },
                        new
                        {
                            Id = new Guid("0e69de60-bd83-4c77-a4e1-b53c17cbe62a"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5149),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5151),
                            Name = "Achiever"
                        },
                        new
                        {
                            Id = new Guid("99a33c0a-5599-4fd0-bf1f-8d37636984a5"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5153),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5155),
                            Name = "Focus"
                        },
                        new
                        {
                            Id = new Guid("cb4e6fcc-e14f-4e1b-a459-cf01a5413b2e"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5157),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5159),
                            Name = "Learner"
                        },
                        new
                        {
                            Id = new Guid("64605f9e-e649-44bc-8250-3061045572c3"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5171),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5172),
                            Name = "Individualization"
                        },
                        new
                        {
                            Id = new Guid("e410bb04-9f99-499c-9bde-159e08df77dc"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5175),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5176),
                            Name = "Self-Assurance"
                        },
                        new
                        {
                            Id = new Guid("56ea1ef4-046d-4fd4-bfe5-93f725f2a852"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5179),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5181),
                            Name = "Activator"
                        },
                        new
                        {
                            Id = new Guid("54cf59e2-6992-4f65-875d-f47ffa02274a"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5234),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5236),
                            Name = "Futuristic"
                        },
                        new
                        {
                            Id = new Guid("f2788720-2652-46e5-9928-a73c4ea3f08b"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5239),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5241),
                            Name = "Connectedness"
                        },
                        new
                        {
                            Id = new Guid("96f241b5-ccc9-4935-b263-69395ea0a167"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5243),
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5245),
                            Name = "Relator"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("InactivatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            CreatedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5493),
                            Email = "domel2222@gmail.com",
                            FirstName = "Dominik",
                            LastName = "Wikliński",
                            ModifiedBy = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                            ModifiedDate = new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5498)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Journal", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Journals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.MostWinDuringTheDay", b =>
                {
                    b.HasOne("Domain.Entities.Journal", "Journal")
                        .WithMany("MostWinsDuringTheDay")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Strenght", "Strenght")
                        .WithMany("MostWinsDuringTheDay")
                        .HasForeignKey("StrenghtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journal");

                    b.Navigation("Strenght");
                });

            modelBuilder.Entity("Domain.Entities.SelfAssessmentValue", b =>
                {
                    b.HasOne("Domain.Entities.Journal", "Journal")
                        .WithMany("SelfAssessmentsValue")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("SelfAssessmentValues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Journal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Journal", b =>
                {
                    b.Navigation("MostWinsDuringTheDay");

                    b.Navigation("SelfAssessmentsValue");
                });

            modelBuilder.Entity("Domain.Entities.Strenght", b =>
                {
                    b.Navigation("MostWinsDuringTheDay");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("SelfAssessmentValues");
                });
#pragma warning restore 612, 618
        }
    }
}
