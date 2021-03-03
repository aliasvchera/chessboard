using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBoard.Models
{
    public class Fortress : Military
    {
        public bool Besieged { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Fortress()
        {
            Type = MilitaryType.Fortress;
        }
        //public override float Streinght()
        //{
        //    float streinght = 0;
        //    foreach(Unit unit in Units)
        //    {
        //        streinght += unit.SoldierNumber * unit.FortressEffectiveness;
        //    }
        //    return streinght;
        //}
    }
}
