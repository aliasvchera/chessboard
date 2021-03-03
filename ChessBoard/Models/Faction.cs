using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoard.Models
{
    public class Faction
    {
        [Key]
        [Column(TypeName = "nvarchar(41)")]
        public string FactionId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public Civilization Civilization { get; }
        public float Money { get; set; }
        public float Reputation { get; set; }        
        public string Pax { get; set; }
        public string Culture { get; set; }
        public List<Military> Militaries { get; set; }

        public Faction(string factionId, Civilization civilization)
        {
            FactionId = factionId;
            Civilization = civilization;
            Money = 0F;
            Reputation = 0F;
        }

    }
}
