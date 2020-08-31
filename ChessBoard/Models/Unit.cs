using System.ComponentModel.DataAnnotations;
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
        [StringLength(20)]
        public string Name { get; }
        public int Speed { get; private set; }
        [Required]
        public int SoldierNumber { get; set; }
        public float Experience { get; set; }
        public float FieldEffectiveness { get; private set; }
        public float FortressEffectiveness { get; private set; }
        public float SiegeEffectiveness { get; private set; }
        //public string FactionName { get; set; }
        //public Faction Faction { get; set; }
        public string MilitaryName { get; set; }
        public Military Military { get; set; }

        //public float CostPerTurn() // use SoldierCost?
        //{
        //    return SoldierCost * SoldierNumber;
        //}

        public Unit(UnitType type, string name, string militaryName, int speed, float fieldEffectiveness, float fortressEffectiveness, float siegeEffectiveness, float soldierCost)
        {
            Type = type;
            Name = name;
            MilitaryName = militaryName;
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
