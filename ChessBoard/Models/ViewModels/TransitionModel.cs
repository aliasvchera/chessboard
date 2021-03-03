using System.Collections.Generic;

namespace ChessBoard.Models.ViewModels
{
    public class TransitionModel
    {
        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<TransitionLine> TransitionLines { get; set; }
    }

    public class TransitionLine
    {
        //public static List<string> region = new List<string>();

        public string RegionName1 { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public string RegionName2 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public bool PermittedForPlayer { get; set; }
    }
}
