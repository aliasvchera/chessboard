using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoard.Models
{
    public abstract class Military
    {
        [Key]
        [Column(TypeName = "nvarchar(41)")]
        public string MilitaryId { get; set; }
        public MilitaryType Type { get; set; }
        [Column(TypeName = "nvarchar(41)")]
        public string FactionId { get; set; }
        public Faction Faction { get; set; }
        [Column(TypeName = "nvarchar(31)")]
        public string RegionId { get; set; }
        public Region Region { get; set; }
        public List<Unit> Units { get; set; }

        //public abstract float Streinght();
    }
}
