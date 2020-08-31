using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoard.Models
{
    public abstract class Military
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
        public MilitaryType Type { get; set; }
        public string FactionName { get; set; }
        public Faction Faction { get; set; }
        public List<Unit> Units { get; set; }
        //public ValueTuple<int, int> Position { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        //public abstract float Streinght();
    }
}
