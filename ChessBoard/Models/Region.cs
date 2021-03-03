using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ChessBoard.Models
{
    public class Region
    {
        [Key]
        [Column(TypeName = "nvarchar(31)")]
        public string RegionId { get; set; }
        // caption name
        public int X { get; set; }
        public int Y { get; set; }
        //public float NormalWealth { get; set; }
        //public float Wealth { get; set; }
        public string Faction { get; set; }
        public List<Army> Armies { get; set; }
        public List<Fortress> Fortresses { get; set; }
        public List<Transition> Transitions1 { get; set; }
        public List<Transition> Transitions2 { get; set; }


        public Region(string regionId, int x, int y)
        {
            RegionId = regionId;
            X = x;
            Y = y;
            //NormalWealth = normalWealth;
            //Wealth = wealth;
        }
        /*
        public float Sack()
        {
            if(EnemyArmy != null)
            {
                var loot = (float) Math.Min(Wealth, EnemyArmy.Units.Sum(r => r.SoldierNumber) * 0.1 * Wealth); // change on const!!!
                Wealth -= loot;
                return loot;
            } 
            else
            {
                return 0;
            }
        }

        public void Improve()
        {
            Wealth = (float) Math.Min(Wealth + 0.01 * NormalWealth, NormalWealth); // change on const!!!
        }*/
    }
}
