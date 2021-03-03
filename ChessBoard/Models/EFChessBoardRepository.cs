using System.Linq;
using ChessBoard.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ChessBoard.Models
{
    public class EFChessBoardRepository : IChessBoardRepository
    {
        private static int newUnitId = 0;
        private readonly ApplicationDbContext context;
        private readonly ILogger _logger = Log.CreateLogger<EFChessBoardRepository>();

        public EFChessBoardRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Faction> Factions => context.Factions;

        public IQueryable<Unit> Units => context.Units;

        public IQueryable<Region> Regions => context.Regions;

        public IQueryable<Transition> Transitions => context.Transitions;

        public IQueryable<Army> Armies => context.Armies;

        public IQueryable<Fortress> Fortresses => context.Fortresses;

        public void AddUnit(string militaryName)
        {            
            var unit = new Unit(UnitType.RomanInfantry, $"test_unit_0{++newUnitId}", militaryName, 1, 10F, 10F, 10F, 0.3F) { SoldierNumber = 100 };
            context.Units.Add(unit);
            context.SaveChanges();
            _logger.LogWarning($"New unit added: test_unit_0{newUnitId}");
            //_logger.LogError($"New unit added: test_unit_0{newUnitId}");
            //System.Diagnostics.Debug.WriteLine($"test_unit_0{newUnitId}");
        }

        public void UpdateDestination(string armyId, string regionId, byte step)
        {
            var army = context.Armies.Where(a => a.MilitaryId == armyId).FirstOrDefault();
            if (army != null)
            {
                if (step == 1)
                {
                    if (army.DestinationRegionId1 is null || !army.DestinationRegionId1.Equals(regionId))
                    {
                        army.DestinationRegionId1 = regionId;                        
                    }
                    else
                    {
                        army.DestinationRegionId1 = null;
                    }
                    army.DestinationRegionId2 = null;
                }
                else
                {
                    if (army.DestinationRegionId2 is null || !army.DestinationRegionId2.Equals(regionId))
                    {
                        army.DestinationRegionId2 = regionId;
                    }
                    else
                    {
                        army.DestinationRegionId2 = null;
                    }                        
                }
                
            }
            //context.Armies.Update(army);
            context.SaveChanges();
        }

        public void ProcessTurn()
        {
            foreach(Army army in context.Armies)
            {
                if (army.DestinationRegionId1 != null)
                {
                    army.RegionId = army.DestinationRegionId1;
                    army.DestinationRegionId1 = army.DestinationRegionId2;
                    army.DestinationRegionId2 = null;
                }                
            }
            context.SaveChanges();
        }
    }
}
