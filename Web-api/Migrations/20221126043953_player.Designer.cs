﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shared.Model;

#nullable disable

namespace api_mrmythical.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221126043953_player")]
    partial class player
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("shared.Model.Ability", b =>
                {
                    b.Property<int>("AbilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AbiltyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("BossId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AbilityId");

                    b.HasIndex("BossId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("shared.Model.Boss", b =>
                {
                    b.Property<int>("BossId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BossName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RaidId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BossId");

                    b.HasIndex("RaidId");

                    b.ToTable("Bosses");
                });

            modelBuilder.Entity("shared.Model.GameClass", b =>
                {
                    b.Property<int>("GameClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GameClassName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameClassId");

                    b.ToTable("GameClasses");
                });

            modelBuilder.Entity("shared.Model.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.HasIndex("GameClassId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("shared.Model.Raid", b =>
                {
                    b.Property<int>("RaidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RaidName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RaidId");

                    b.ToTable("Raids");
                });

            modelBuilder.Entity("shared.Model.Spell", b =>
                {
                    b.Property<int>("SpellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpellName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Wowhead")
                        .HasColumnType("INTEGER");

                    b.HasKey("SpellId");

                    b.HasIndex("GameClassId");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("shared.Model.Ability", b =>
                {
                    b.HasOne("shared.Model.Boss", null)
                        .WithMany("Abilities")
                        .HasForeignKey("BossId");
                });

            modelBuilder.Entity("shared.Model.Boss", b =>
                {
                    b.HasOne("shared.Model.Raid", null)
                        .WithMany("Bosses")
                        .HasForeignKey("RaidId");
                });

            modelBuilder.Entity("shared.Model.Player", b =>
                {
                    b.HasOne("shared.Model.GameClass", "GameClass")
                        .WithMany()
                        .HasForeignKey("GameClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameClass");
                });

            modelBuilder.Entity("shared.Model.Spell", b =>
                {
                    b.HasOne("shared.Model.GameClass", null)
                        .WithMany("Spells")
                        .HasForeignKey("GameClassId");
                });

            modelBuilder.Entity("shared.Model.Boss", b =>
                {
                    b.Navigation("Abilities");
                });

            modelBuilder.Entity("shared.Model.GameClass", b =>
                {
                    b.Navigation("Spells");
                });

            modelBuilder.Entity("shared.Model.Raid", b =>
                {
                    b.Navigation("Bosses");
                });
#pragma warning restore 612, 618
        }
    }
}
