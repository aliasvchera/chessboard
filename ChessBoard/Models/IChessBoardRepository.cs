using System.Linq;

namespace ChessBoard.Models
{
    public interface IChessBoardRepository
    {
        public IQueryable<Faction> Factions { get; }
        public IQueryable<Unit> Units { get; }
        public IQueryable<Region> Regions { get; }
        public IQueryable<Transition> Transitions { get; }
        public IQueryable<Army> Armies { get; }
        public IQueryable<Fortress> Fortresses { get; }
        void AddUnit(string militaryName);
        void UpdateDestination(string armyId, string regionId, byte step);
        void ProcessTurn();
    }
}
