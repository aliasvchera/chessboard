using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace ChessBoard.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Faction> Factions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<Fortress> Fortresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converterCivilization = new EnumToStringConverter<Civilization>();
            modelBuilder.Entity<Faction>()
                .Property(f => f.Civilization)
                .HasConversion(converterCivilization);

            var converterUnitType = new EnumToStringConverter<UnitType>();
            modelBuilder.Entity<Unit>()
                .Property(u => u.Type)
                .HasConversion(converterUnitType);

            var converterMilitaryType = new EnumToStringConverter<MilitaryType>();
            modelBuilder.Entity<Army>()
                .Property(a => a.Type)
                .HasConversion(converterMilitaryType);
            modelBuilder.Entity<Fortress>()
                .Property(f => f.Type)
                .HasConversion(converterMilitaryType);

            modelBuilder.Entity<Faction>()
                .HasKey(f => f.Name);

            modelBuilder.Entity<Unit>()
                .HasKey(u => u.Name);

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Military)
                .WithMany(f => f.Units)
                .HasForeignKey(u => u.MilitaryName)
                .HasPrincipalKey(f => f.Name);

            /*modelBuilder.Entity<Region>()
                .HasNoKey();*/

            modelBuilder.Entity<Transition>()
                .HasKey(c => new { c.RegionName1, c.RegionName2 });

            modelBuilder.Entity<Transition>()
                .HasOne(t => t.Region1)
                .WithMany(r => r.Transitions1)
                .HasForeignKey(t => t.RegionName1);

            modelBuilder.Entity<Transition>()
                .HasOne(t => t.Region2)
                .WithMany(r => r.Transitions2)
                .HasForeignKey(t => t.RegionName2)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transition>()
                .Property(t => t.Factions)
                .HasConversion(
                    f => string.Join('|', f),
                    f => f.Split('|', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
