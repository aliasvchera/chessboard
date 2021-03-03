using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ChessBoard.Models
{
    public class Unit
    {
        //private readonly float soldierCost;
        public float SoldierCost { get; private set; }
        public UnitType Type { get; } // Roman infantry/cavalry, Foederati infantry/cavalry
        // Symbol of unit type
        // Symbol of cohort
        // Position of unit type symbol in army icon (1,2,3,...)
        [Required]
        [StringLength(41)]
        public string UnitId { get; set; }
        public int Speed { get; private set; }
        [Required]
        public int SoldierNumber { get; set; }
        public float Experience { get; set; }
        public float FieldEffectiveness { get; private set; }
        public float FortressEffectiveness { get; private set; }
        public float SiegeEffectiveness { get; private set; }
        [Column(TypeName = "nvarchar(41)")]
        public string MilitaryId { get; set; }
        public Military Military { get; set; }

        //public float CostPerTurn() // use SoldierCost?
        //{
        //    return SoldierCost * SoldierNumber;
        //}

        public Unit(UnitType type, string unitId, string militaryId, int speed, float fieldEffectiveness, float fortressEffectiveness, float siegeEffectiveness, float soldierCost)
        {
            Type = type;
            UnitId = unitId;
            MilitaryId = militaryId;
            Speed = speed;
            SoldierNumber = 0;
            Experience = 1F;
            FieldEffectiveness = fieldEffectiveness;
            FortressEffectiveness = fortressEffectiveness;
            SiegeEffectiveness = siegeEffectiveness;
            SoldierCost = soldierCost;
        }
    }
}
