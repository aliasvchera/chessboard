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
    [Migration("20210110125701_AddRegionKey")]
    partial class AddRegionKey
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
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasKey("Name");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("ChessBoard.Models.Military", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactionName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.HasIndex("FactionName");

                    b.HasIndex("RegionName");

                    b.ToTable("Military");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Military");
                });

            modelBuilder.Entity("ChessBoard.Models.Region", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Faction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ChessBoard.Models.Transition", b =>
                {
                    b.Property<string>("RegionName1")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RegionName2")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Factions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Penalty")
                        .HasColumnType("real");

                    b.HasKey("RegionName1", "RegionName2");

                    b.HasIndex("RegionName2");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("ChessBoard.Models.Unit", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<float>("Experience")
                        .HasColumnType("real");

                    b.Property<string>("FactionName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("FieldEffectiveness")
                        .HasColumnType("real");

                    b.Property<float>("FortressEffectiveness")
                        .HasColumnType("real");

                    b.Property<string>("MilitaryName")
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

                    b.HasKey("Name");

                    b.HasIndex("FactionName");

                    b.HasIndex("MilitaryName");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ChessBoard.Models.Army", b =>
                {
                    b.HasBaseType("ChessBoard.Models.Military");

                    b.Property<string>("Besieging")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasDiscriminator().HasValue("Fortress");
                });

            modelBuilder.Entity("ChessBoard.Models.Military", b =>
                {
                    b.HasOne("ChessBoard.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionName");

                    b.HasOne("ChessBoard.Models.Region", "Region")
                        .WithMany("Militaries")
                        .HasForeignKey("RegionName");
                });

            modelBuilder.Entity("ChessBoard.Models.Transition", b =>
                {
                    b.HasOne("ChessBoard.Models.Region", "Region1")
                        .WithMany("Transitions1")
                        .HasForeignKey("RegionName1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChessBoard.Models.Region", "Region2")
                        .WithMany("Transitions2")
                        .HasForeignKey("RegionName2")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ChessBoard.Models.Unit", b =>
                {
                    b.HasOne("ChessBoard.Models.Faction", null)
                        .WithMany("Units")
                        .HasForeignKey("FactionName");

                    b.HasOne("ChessBoard.Models.Military", "Military")
                        .WithMany("Units")
                        .HasForeignKey("MilitaryName");
                });
#pragma warning restore 612, 618
        }
    }
}
