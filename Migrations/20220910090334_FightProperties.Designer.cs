﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_webapi.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220910090334_FightProperties")]
    partial class FightProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CharactorSkill", b =>
                {
                    b.Property<int>("CharactorsId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("CharactorsId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("CharactorSkill");
                });

            modelBuilder.Entity("dotnet_webapi.Models.Charactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defeats")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Fights")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Charactors");
                });

            modelBuilder.Entity("dotnet_webapi.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 30,
                            Name = "Fireball"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 20,
                            Name = "Frenzy"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 50,
                            Name = "Blizzard"
                        });
                });

            modelBuilder.Entity("dotnet_webapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dotnet_webapi.Models.Weapons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CharactorId")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharactorId")
                        .IsUnique();

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("CharactorSkill", b =>
                {
                    b.HasOne("dotnet_webapi.Models.Charactor", null)
                        .WithMany()
                        .HasForeignKey("CharactorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotnet_webapi.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dotnet_webapi.Models.Charactor", b =>
                {
                    b.HasOne("dotnet_webapi.Models.User", "User")
                        .WithMany("Charactors")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("dotnet_webapi.Models.Weapons", b =>
                {
                    b.HasOne("dotnet_webapi.Models.Charactor", "Charactor")
                        .WithOne("Weapons")
                        .HasForeignKey("dotnet_webapi.Models.Weapons", "CharactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Charactor");
                });

            modelBuilder.Entity("dotnet_webapi.Models.Charactor", b =>
                {
                    b.Navigation("Weapons")
                        .IsRequired();
                });

            modelBuilder.Entity("dotnet_webapi.Models.User", b =>
                {
                    b.Navigation("Charactors");
                });
#pragma warning restore 612, 618
        }
    }
}
