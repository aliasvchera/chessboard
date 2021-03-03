using System.Collections.Generic;
using System.Linq;

namespace ChessBoard.Models
{
    public static class UserDataManipulation
    {
        public static void DeleteGame(ApplicationDbContext context, string userName)
        {
            var userTransitions = context.Transitions.Where(m => m.RegionId1.StartsWith(userName + "|"));
            context.Transitions.RemoveRange(userTransitions);

            var userUnits = context.Units.Where(m => m.UnitId.StartsWith(userName + "|"));
            context.Units.RemoveRange(userUnits);

            var userArmies = context.Armies.Where(m => m.MilitaryId.StartsWith(userName + "|"));
            context.Armies.RemoveRange(userArmies);

            var userFortresses = context.Fortresses.Where(m => m.MilitaryId.StartsWith(userName + "|"));
            context.Fortresses.RemoveRange(userFortresses);

            var userRegions = context.Regions.Where(f => f.RegionId.StartsWith(userName + "|"));
            context.Regions.RemoveRange(userRegions);

            var userFactions = context.Factions.Where(f => f.FactionId.StartsWith(userName + "|"));
            context.Factions.RemoveRange(userFactions);
        }

        public static void NewGame(ApplicationDbContext context, string userName)
        {
            DeleteGame(context, userName);

            List<Faction> factions = context.Factions.Where(f => f.FactionId.StartsWith("|")).ToList();
            foreach (Faction f in factions)
            {
                f.FactionId = userName + f.FactionId;
            }
            context.Factions.AddRange(factions);
            context.SaveChanges();

            List<Region> regions = context.Regions.Where(f => f.RegionId.StartsWith("|")).ToList();
            foreach (Region r in regions)
            {
                r.RegionId = userName + r.RegionId;
                r.Faction = userName + r.Faction;
            }
            context.Regions.AddRange(regions);
            context.SaveChanges();

            List<Army> armies = context.Armies.Where(m => m.MilitaryId.StartsWith("|")).ToList();
            foreach (Army a in armies)
            {
                a.MilitaryId = userName + a.MilitaryId;
                a.FactionId = userName + a.FactionId;
                a.RegionId = userName + a.RegionId;
            }
            context.Armies.AddRange(armies);
            context.SaveChanges();

            List<Fortress> fortresses = context.Fortresses.Where(m => m.MilitaryId.StartsWith("|")).ToList();
            foreach (Fortress f in fortresses)
            {
                f.MilitaryId = userName + f.MilitaryId;
                f.FactionId = userName + f.FactionId;
                f.RegionId = userName + f.RegionId;
            }
            context.Fortresses.AddRange(fortresses);
            context.SaveChanges();

            List<Unit> units = context.Units.Where(m => m.UnitId.StartsWith("|")).ToList();
            foreach (Unit u in units)
            {
                u.UnitId = userName + u.UnitId;
                u.MilitaryId = userName + u.MilitaryId;
            }
            context.Units.AddRange(units);
            context.SaveChanges();

            List<Transition> transitions = context.Transitions.Where(m => m.RegionId1.StartsWith("|")).ToList();
            foreach (Transition t in transitions)
            {
                t.RegionId1 = userName + t.RegionId1;
                t.RegionId2 = userName + t.RegionId2;
                for (int i = 0; i < t.Factions.Length; i++)
                {
                    t.Factions[i] = userName + t.Factions[i];
                }
            }
            context.Transitions.AddRange(transitions);
            context.SaveChanges();
        }
    }
}
