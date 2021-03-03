﻿// <auto-generated />
using ChessBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChessBoard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210112155823_FactionKey2")]
    partial class FactionKey2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChessBoard.Models.Faction", b =>
                {
                    b.Property<string>("FactionId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Civilization")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Culture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Money")
                        .HasColumnType("real");

                    b.Property<string>("Pax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Reputation")
                        .HasColumnType("real");

                    b.HasKey("FactionId");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("ChessBoard.Models.Military", b =>
                {
                    b.Property<string>("MilitaryId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactionId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RegionId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MilitaryId");

                    b.HasIndex("FactionId");

                    b.ToTable("Military");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Military");
                });

            modelBuilder.Entity("ChessBoard.Models.Region", b =>
                {
                    b.Property<string>("RegionId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Faction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ChessBoard.Models.Transition", b =>
                {
                    b.Property<string>("RegionId1")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RegionId2")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Factions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Penalty")
                        .HasColumnType("real");

                    b.HasKey("RegionId1", "RegionId2");

                    b.HasIndex("RegionId2");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("ChessBoard.Models.Unit", b =>
                {
                    b.Property<string>("UnitId")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<float>("Experience")
                        .HasColumnType("real");

                    b.Property<string>("FactionId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("FieldEffectiveness")
                        .HasColumnType("real");

                    b.Property<float>("FortressEffectiveness")
                        .HasColumnType("real");

                    b.Property<string>("MilitaryId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("SiegeEffectiveness")
                        .HasColumnType("real");

                    b.Property<float>("SoldierCost")
                        .HasColumnType("real");

                    b.Property<int>("SoldierNumber")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.HasIndex("FactionId");

                    b.HasIndex("MilitaryId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ChessBoard.Models.Army", b =>
                {
                    b.HasBaseType("ChessBoard.Models.Military");

                    b.Property<string>("Besieging")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("RegionId");

                    b.HasDiscriminator().HasValue("Army");
                });

            modelBuilder.Entity("ChessBoard.Models.Fortress", b =>
                {
                    b.HasBaseType("ChessBoard.Models.Military");

                    b.Property<bool>("Besieged")
                        .HasColumnType("bit");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasIndex("RegionId")
                        .HasName("IX_Military_RegionId1");

                    b.HasDiscriminator().HasValue("Fortress");
                });

            modelBuilder.Entity("ChessBoard.Models.Military", b =>
                {
                    b.HasOne("ChessBoard.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId");
                });

            modelBuilder.Entity("ChessBoard.Models.Transition", b =>
                {
                    b.HasOne("ChessBoard.Models.Region", "Region1")
                        .WithMany("Transitions1")
                        .HasForeignKey("RegionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChessBoard.Models.Region", "Region2")
                        .WithMany("Transitions2")
                        .HasForeignKey("RegionId2")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ChessBoard.Models.Unit", b =>
                {
                    b.HasOne("ChessBoard.Models.Faction", null)
                        .WithMany("Units")
                        .HasForeignKey("FactionId");

                    b.HasOne("ChessBoard.Models.Military", "Military")
                        .WithMany("Units")
                        .HasForeignKey("MilitaryId");
                });

            modelBuilder.Entity("ChessBoard.Models.Army", b =>
                {
                    b.HasOne("ChessBoard.Models.Region", "Region")
                        .WithMany("Armies")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("ChessBoard.Models.Fortress", b =>
                {
                    b.HasOne("ChessBoard.Models.Region", "Region")
                        .WithMany("Fortresses")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_Military_Regions_RegionId1");
                });
#pragma warning restore 612, 618
        }
    }
}
