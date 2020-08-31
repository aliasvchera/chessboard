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
        [Column(TypeName = "nvarchar(10)")]
        public string Name { get; set; }
        // caption name
        // private readonly colour;
        //public Location Location { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public float NormalWealth { get; set; }
        public float Wealth { get; set; }
        public string Faction { get; set; }
        /*public Fortress? Fortress { get; set; }
        public Army? Army { get; set; }
        public Army? EnemyArmy { get; set; }*/
        public List<Transition> Transitions1 { get; set; }
        public List<Transition> Transitions2 { get; set; }


        public Region(string name, int x, int y, float normalWealth, float wealth)
        {
            Name = name;
            X = x;
            Y = y;
            //Location = new Location(location.x, location.y);
            NormalWealth = normalWealth;
            Wealth = wealth;
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
