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
    [Migration("20200714100345_Transitions")]
    partial class Transitions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
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

            modelBuilder.Entity("ChessBoard.Models.Transition", b =>
                {
                    b.Property<int>("TransitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Factions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Penalty")
                        .HasColumnType("real");

                    b.HasKey("TransitionId");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("ChessBoard.Models.Unit", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Experience")
                        .HasColumnType("real");

                    b.Property<string>("FactionName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("FieldEffectiveness")
                        .HasColumnType("real");

                    b.Property<float>("FortressEffectiveness")
                        .HasColumnType("real");

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

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ChessBoard.Models.Unit", b =>
                {
                    b.HasOne("ChessBoard.Models.Faction", "Faction")
                        .WithMany("Units")
                        .HasForeignKey("FactionName");
                });
#pragma warning restore 612, 618
        }
    }
}
