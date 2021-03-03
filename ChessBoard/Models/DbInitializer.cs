using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChessBoard.Models
{
    public static class DbInitializer
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //if (context.Factions.Any())
            //{
            //    return;
            //}
            //UserDataManipulation.DeleteGame(context, "");

            context.Transitions.Clear();
            context.Units.Clear();
            context.Fortresses.Clear();
            context.Armies.Clear();
            context.Regions.Clear();
            context.Factions.Clear();

            var factions = new List<Faction>()
            {
                new Faction("|Imperator", Civilization.PaxRomana),
                new Faction("|MM_per_Thracias", Civilization.PaxRomana),
                new Faction("|Gothi", Civilization.PaxBarbarica)
            };
            foreach (Faction f in factions)
            {
                context.Factions.Add(f);
            }
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region("|dac_rip_01", x: 115, y: 289) { Faction = "|MM_per_Thracias" },
                new Region("|dac_rip_02", x: 185, y: 330) { Faction = "|MM_per_Thracias" },
                new Region("|dac_rip_03", x: 260, y: 420) { Faction = "|MM_per_Thracias" },
                new Region("|dac_rip_04", x: 253, y: 508) { Faction = "|MM_per_Thracias" },
                new Region("|dac_rip_05", x: 210, y: 522) { Faction = "|MM_per_Thracias" },
                new Region("|dac_rip_06", x: 394, y: 522) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_01", x: 510, y: 475) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_02", x: 531, y: 548) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_03", x: 419, y: 603) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_04", x: 395, y: 657) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_05", x: 614, y: 625) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_06", x: 600, y: 675) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_07", x: 754, y: 510) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_08", x: 740, y: 580) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_09", x: 1007, y: 411) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_10", x: 935, y: 555) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_11", x: 1000, y: 615) { Faction = "|MM_per_Thracias" },
                new Region("|moe_inf_12", x: 955, y: 658) { Faction = "|MM_per_Thracias" },
                new Region("|scy_min_01", x: 1050, y: 205) { Faction = "|MM_per_Thracias" },
                new Region("|scy_min_02", x: 1083, y: 411) { Faction = "|MM_per_Thracias" },
                new Region("|dac_bar_01", x: 419, y: 286) { Faction = "|Gothi" },
                new Region("|dac_bar_02", x: 309, y: 340) { Faction = "|Gothi" },
                new Region("|dac_bar_03", x: 690, y: 370) { Faction = "|Gothi" },
                new Region("|dac_bar_04", x: 635, y: 450) { Faction = "|Gothi" },
                new Region("|dac_bar_05", x: 900, y: 220) { Faction = "|Gothi" },
                new Region("|dac_bar_06", x: 990, y: 340) { Faction = "|Gothi" },
                new Region("|dac_bar_07", x: 994, y: 28) { Faction = "|Gothi" },
                new Region("|dac_bar_08", x: 1092, y: 105) { Faction = "|Gothi" }
            };
            foreach (Region r in regions)
            {
                context.Regions.Add(r);
            }
            context.SaveChanges();

            var armies = new List<Army>()
            {
                new Army { MilitaryId = "|vexillatio_01", FactionId = "|MM_per_Thracias", RegionId = "|dac_rip_03"},
                new Army { MilitaryId = "|vexillatio_02", FactionId = "|MM_per_Thracias", RegionId = "|moe_inf_10"},
                new Army { MilitaryId = "|warband_01", FactionId = "|Gothi", RegionId = "|dac_bar_03"}
            };
            foreach (Army a in armies)
            {
                context.Armies.Add(a);
            }
            context.SaveChanges();
            
            var fortresses = new List<Fortress>()
            {
                new Fortress { MilitaryId = "|Oescus", FactionId = "|MM_per_Thracias", RegionId = "|moe_inf_01", X = 580, Y = 480 },
                new Fortress { MilitaryId = "|Duristorum", FactionId = "|MM_per_Thracias", RegionId = "|moe_inf_09", X = 925, Y = 430 }
            };
            foreach (Fortress f in fortresses)
            {
                context.Fortresses.Add(f);
            }
            context.SaveChanges();

            var units = new List<Unit>()
            {
                new Unit(UnitType.RomanInfantry, "|limit_01", "|Duristorum", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 100 },
                new Unit(UnitType.RomanCavalry, "|limit_02", "|Duristorum", 2, 10F, 10F, 10F, 0.3F) { SoldierNumber = 20 },
                new Unit(UnitType.RomanInfantry, "|comit_03", "|vexillatio_01", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 30 },
                new Unit(UnitType.RomanCavalry, "|palat_01", "|vexillatio_02", 2, 10F, 10F, 10F, 0.3F) { SoldierNumber = 50 },
                new Unit(UnitType.RomanInfantry, "|palat_02", "|vexillatio_02", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 33 },
                new Unit(UnitType.BarbarianCavalry, "|barbar_01", "|warband_01", 2, 10F, 10F, 10F, 0.3F) { SoldierNumber = 70 },
                new Unit(UnitType.BarbarianInfantry, "|barbar_02", "|warband_01", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 200 }
            };
            foreach (Unit u in units)
            {
                context.Units.Add(u);
            }
            context.SaveChanges();
            
            var transitions = new List<Transition>()
            {
                { new Transition("|dac_rip_01", "|dac_rip_02", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|dac_rip_03", "|dac_rip_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_rip_03", "|dac_bar_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_02", "|dac_bar_01", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_rip_03", "|dac_rip_04", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_rip_04", "|dac_rip_05", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|dac_rip_04", "|dac_rip_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_rip_03", "|dac_rip_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_01", "|dac_rip_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_01", "|dac_rip_03", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_01", "|moe_inf_07", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_02", "|dac_rip_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_03", "|dac_rip_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_02", "|moe_inf_01", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_02", "|moe_inf_08", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_02", "|moe_inf_05", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_05", "|moe_inf_06", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|moe_inf_03", "|moe_inf_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_03", "|moe_inf_04", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|moe_inf_05", "|moe_inf_08", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_08", "|moe_inf_07", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_09", "|moe_inf_07", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_10", "|moe_inf_08", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_10", "|moe_inf_07", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_10", "|scy_min_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_10", "|moe_inf_09", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_10", "|moe_inf_11", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_11", "|moe_inf_12", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|moe_inf_09", "|scy_min_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_11", "|scy_min_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_09", "|scy_min_01", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|scy_min_02", "|scy_min_01", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|scy_min_02", "|dac_bar_08", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_09", "|dac_bar_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_07", "|dac_bar_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_07", "|dac_bar_04", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_01", "|dac_bar_04", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|moe_inf_01", "|dac_bar_02", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_02", "|dac_bar_04", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_04", "|dac_bar_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_06", "|dac_bar_08", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_08", "|dac_bar_07", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|dac_bar_07", "|dac_bar_05", new string[]{ "|Gothi" }, 0F, false) },
                { new Transition("|dac_bar_05", "|dac_bar_08", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_05", "|dac_bar_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_05", "|dac_bar_03", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_03", "|dac_bar_06", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_03", "|dac_bar_04", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_03", "|dac_bar_01", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) },
                { new Transition("|dac_bar_01", "|dac_bar_04", new string[]{ "|MM_per_Thracias", "|Gothi" }, 0F, true) }
            };
            foreach(Transition t in transitions)
            {
                context.Transitions.Add(t);
            }
            context.SaveChanges();
        }
    }
}
