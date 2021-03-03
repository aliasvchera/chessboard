using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBoard.Models.ViewModels
{
    public class MilitaryModel
    {
        public static string selectedArmy;
        public readonly string playerFaction;

        public MilitaryModel(string playerFaction)
        {
            this.playerFaction = playerFaction;
        }

        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<Faction> Factions { get; set; }
        public IEnumerable<string> DestinationRegions0 { get; set; }
        public IEnumerable<string> DestinationRegions1 { get; set; }
        public IEnumerable<string> Romans { get; set; }
        public IEnumerable<string> Barbarians { get; set; }
    }
}
