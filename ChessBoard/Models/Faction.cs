using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoard.Models
{
    public class Faction
    {
        public string Name { get; }

        [Column(TypeName = "nvarchar(20)")]
        public Civilization Civilization { get; }
        public float Money { get; set; }
        public float Reputation { get; set; }
        // tmp
        public string Pax { get; set; }
        public string Culture { get; set; }
        // tmp
        public List<Unit> Units { get; set; }

        public Faction(string name, Civilization civilization)
        {
            Name = name;
            Civilization = civilization;
            Money = 0F;
            Reputation = 0F;
        }

    }
}
