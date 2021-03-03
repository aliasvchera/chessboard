using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;

namespace ChessBoard.Models
{
    public class Army : Military
    {
        public string Besieging { get; set; }

        [Column(TypeName = "nvarchar(31)")]
        public string DestinationRegionId1 { get; set; }

        [Column(TypeName = "nvarchar(31)")]
        public string DestinationRegionId2 { get; set; }

        public Army()
        {
            Type = MilitaryType.Army;
        }
        //public override float Streinght()
        //{
        //    float streinght = 0;
        //    if (Besieging)
        //    {
        //        foreach (Unit unit in Units)
        //        {
        //            streinght += unit.SoldierNumber * unit.SiegeEffectiveness;
        //        }
        //    } else 
        //    { 
        //        foreach (Unit unit in Units)
        //        {
        //            streinght += unit.SoldierNumber * unit.FieldEffectiveness;
        //        }
        //    }
        //    return streinght;
        //}

        //public int Speed
        //{
        //    get
        //    {
        //        return Units.Where(r => r.SoldierNumber > 0).Min(r => r.Speed);
        //    }
        //}

        //private double Distance(double a, double b, double c, double x0, double y0)
        //{
        //    return Math.Abs(a * x0 + b * y0 + c) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        //}
        /*
        public List<Region> FindPath(Region target) // Queue?
        {
            double distanceL = 10; // change to const parameters
            double distanceH = 10; // change to const parameters

            // line L: from starting point A(x1, y1) to destination B(x2, y2)
            // [a * x + b * y + c = 0]: (y1 - y2) * x + (x2 - x1) * y + (x1 * y2 + x2 * y1) = 0
            // [y = k * x + m]: y = ((y2 - y1) / (x2 - x1)) * x + (x2 * y1 - x1 * y2) / (x2 - x1)
            double aL = Position.Item2 - target.Location.Y;
            double bL = target.Location.X - Position.Item1;
            double cL = Position.Item1 * target.Location.Y + target.Location.X * Position.Item2;
            
            // line H: perpendicular to line L, crossing line L in the middle point C(x3, y3) of distance between start A and destination B
            // C(x3, y3): x3 = (x1 + x2) / 2, y3 = (y1 + y2) / 2
            // y - y3 = -1/k * (x - x3)
            // [y = k * x + m]: y = -1 / k * x + (x3 / k + y3)
            // [a * x + b * y + c = 0]: (1 / k) * x + 1 * y + (x3 / k + y3) = 0
            double aH = 1 / (aL / bL);
            double bH = 1;
            double cH = ((Position.Item1 + target.Location.X) / 2) / (aL / bL) + (Position.Item2 + target.Location.Y) / 2;

            var regionsRange = RegionRepository.Regions.Where(r => r.Faction == this.Faction
                && Distance(aL, bL, cL, r.Location.X, r.Location.Y) == distanceL && Distance(aH, bH, cH, r.Location.X, r.Location.Y) == distanceH)
                .ToList<Region>();

            // var pathes = TransitionRepository.Transitions.Where(r => r.Key.Item1 == regionsRange.Name && r.Key.Item2 == regionsRange.Name);

            return regionsRange; // result;
        }*/
    }
}
