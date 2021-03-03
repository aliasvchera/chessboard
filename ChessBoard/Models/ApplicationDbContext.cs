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
                .HasKey(f => f.FactionId);

            modelBuilder.Entity<Unit>()
                .HasKey(u => u.UnitId);

            modelBuilder.Entity<Region>()
                .HasKey(r => r.RegionId);

            /*modelBuilder.Entity<Region>()
                .HasNoKey();*/

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Military)
                .WithMany(f => f.Units)
                .HasForeignKey(u => u.MilitaryId)
                .HasPrincipalKey(f => f.MilitaryId);

            modelBuilder.Entity<Army>()
                .HasOne(m => m.Region)
                .WithMany(r => r.Armies)
                .HasForeignKey(m => m.RegionId)
                .HasPrincipalKey(r => r.RegionId);

            modelBuilder.Entity<Fortress>()
                .HasOne(m => m.Region)
                .WithMany(r => r.Fortresses)
                .HasForeignKey(m => m.RegionId)
                .HasPrincipalKey(r => r.RegionId);

            modelBuilder.Entity<Military>()
                .HasOne(a => a.Faction)
                .WithMany(r => r.Militaries)
                .HasForeignKey(a => a.FactionId)
                .HasPrincipalKey(r => r.FactionId);

            //modelBuilder.Entity<Fortress>()
            //    .HasOne(m => m.Region)
            //    .WithMany(r => r.Fortresses)
            //    .HasForeignKey(m => m.RegionId)
            //    .HasPrincipalKey(r => r.RegionId);

            modelBuilder.Entity<Transition>()
                .HasKey(c => new { c.RegionId1, c.RegionId2 });

            modelBuilder.Entity<Transition>()
                .HasOne(t => t.Region1)
                .WithMany(r => r.Transitions1)
                .HasForeignKey(t => t.RegionId1);

            modelBuilder.Entity<Transition>()
                .HasOne(t => t.Region2)
                .WithMany(r => r.Transitions2)
                .HasForeignKey(t => t.RegionId2)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transition>()
                .Property(t => t.Factions)
                .HasConversion(
                    f => string.Join('|', f),
                    f => f.Split('|', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
