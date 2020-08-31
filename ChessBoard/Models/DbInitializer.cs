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
            context.Factions.Clear();
            var factions = new List<Faction>()
            {
                new Faction("Imperator", Civilization.PaxRomana),
                new Faction("MM_per_Thracias", Civilization.PaxRomana),
                new Faction("Gothi", Civilization.PaxBarbarica)
            };
            foreach (Faction f in factions)
            {
                context.Factions.Add(f);
            }
            context.SaveChanges();

            context.Armies.Clear();
            var armies = new List<Army>()
            {
                new Army { Name = "vexillatio_01", FactionName = "MM_per_Thracias", X = 260, Y = 420 },
                new Army { Name = "vexillatio_02", FactionName = "MM_per_Thracias", X = 935, Y = 555 },
                new Army { Name = "warband_01", FactionName = "Gothi", X = 690, Y = 370 }
            };
            foreach (Army a in armies)
            {
                context.Armies.Add(a);
            }
            context.SaveChanges();

            context.Fortresses.Clear();
            var fortresses = new List<Fortress>()
            {
                new Fortress { Name = "oescus", FactionName = "MM_per_Thracias", X = 580, Y = 480 },
                new Fortress { Name = "duristorum", FactionName = "MM_per_Thracias", X = 925, Y = 435 }
            };
            foreach (Fortress f in fortresses)
            {
                context.Fortresses.Add(f);
            }
            context.SaveChanges();

            context.Units.Clear();
            var units = new List<Unit>()
            {
                new Unit(UnitType.RomanInfantry, "limit_01", "duristorum", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 100 },
                new Unit(UnitType.RomanCavalry, "limit_02", "duristorum", 2, 10F, 10F, 10F, 0.3F) { SoldierNumber = 20 },
                new Unit(UnitType.RomanInfantry, "comit_03", "vexillatio_01", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 30 },
                new Unit(UnitType.RomanCavalry, "palat_01", "vexillatio_02", 2, 10F, 10F, 10F, 0.3F) { SoldierNumber = 50 },
                new Unit(UnitType.RomanInfantry, "palat_02", "vexillatio_02", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 33 },
                new Unit(UnitType.BarbarianCavalry, "barbar_01", "warband_01", 2, 10F, 10F, 10F, 0.3F) { SoldierNumber = 70 },
                new Unit(UnitType.BarbarianInfantry, "barbar_02", "warband_01", 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 200 }
            };
            foreach (Unit u in units)
            {
                context.Units.Add(u);
            }
            context.SaveChanges();

            context.Regions.Clear();
            var regions = new List<Region>
            {
                new Region("dac_rip_01", 115, y: 289, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("dac_rip_02", 185, y: 330, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("dac_rip_03", 279, y: 431, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("dac_rip_04", 253, y: 508, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("dac_rip_05", 210, y: 522, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("dac_rip_06", 394, y: 522, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_01", 510, y: 475, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_02", 531, y: 548, 100, 90) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_03", 419, y: 603, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_04", 395, y: 657, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_05", 614, y: 625, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_06", 600, y: 675, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_07", 754, y: 510, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_08", 740, y: 580, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_09", 1007, y: 411, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_10", 916, y: 520, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_11", 1000, y: 615, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("moe_inf_12", 955, y: 658, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("scy_min_01", 1050, y: 205, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("scy_min_02", 1083, y: 411, 100, 100) { Faction = "MM_per_Thracias"},
                new Region("dac_bar_01", 419, y: 286, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_02", 309, y: 340, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_03", 694, y: 310, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_04", 635, y: 450, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_05", 900, y: 220, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_06", 990, y: 340, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_07", 994, y: 28, 100, 100) { Faction = "Gothi"},
                new Region("dac_bar_08", 1092, y: 105, 100, 100) { Faction = "Gothi"}
            };
            foreach(Region r in regions)
            {
                context.Regions.Add(r);
            }
            context.SaveChanges();

            context.Transitions.Clear();
            var transitions = new List<Transition>()
            {
                { new Transition("dac_rip_01", "dac_rip_02", new string[]{ "Gothi" }, 0F) },
                { new Transition("dac_rip_03", "dac_rip_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_rip_03", "dac_bar_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_02", "dac_bar_01", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_rip_03", "dac_rip_04", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_rip_04", "dac_rip_05", new string[]{ "Gothi" }, 0F) },
                { new Transition("dac_rip_04", "dac_rip_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_rip_03", "dac_rip_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_01", "dac_rip_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_01", "dac_rip_03", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_01", "moe_inf_07", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_02", "dac_rip_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_03", "dac_rip_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_02", "moe_inf_01", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_02", "moe_inf_08", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_02", "moe_inf_05", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_05", "moe_inf_06", new string[]{ "Gothi" }, 0F) },
                { new Transition("moe_inf_03", "moe_inf_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_03", "moe_inf_04", new string[]{ "Gothi" }, 0F) },
                { new Transition("moe_inf_05", "moe_inf_08", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_08", "moe_inf_07", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_09", "moe_inf_07", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_10", "moe_inf_08", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_10", "moe_inf_07", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_10", "scy_min_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_10", "moe_inf_09", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_10", "moe_inf_11", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_11", "moe_inf_12", new string[]{ "Gothi" }, 0F) },
                { new Transition("moe_inf_09", "scy_min_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_11", "scy_min_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_09", "scy_min_01", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("scy_min_02", "scy_min_01", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("scy_min_02", "dac_bar_08", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_09", "dac_bar_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_07", "dac_bar_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_07", "dac_bar_04", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_01", "dac_bar_04", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("moe_inf_01", "dac_bar_02", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_02", "dac_bar_04", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_04", "dac_bar_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_06", "dac_bar_08", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_08", "dac_bar_07", new string[]{ "Gothi" }, 0F) },
                { new Transition("dac_bar_07", "dac_bar_05", new string[]{ "Gothi" }, 0F) },
                { new Transition("dac_bar_05", "dac_bar_08", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_05", "dac_bar_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_05", "dac_bar_03", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_03", "dac_bar_06", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_03", "dac_bar_04", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_03", "dac_bar_01", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
                { new Transition("dac_bar_01", "dac_bar_04", new string[]{ "MM_per_Thracias", "Gothi" }, 0F) }
            };
            foreach(Transition t in transitions)
            {
                context.Transitions.Add(t);
            }
            context.SaveChanges();
        }
    }
}
