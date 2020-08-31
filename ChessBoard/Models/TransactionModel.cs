using System.Collections.Generic;

namespace ChessBoard.Models
{
    public class TransactionModel
    {
        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<TransactionLine> TransactionLines { get; set; }
    }

    public class TransactionLine
    {
        //public static List<string> region = new List<string>();

        public string RegionName1 { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public string RegionName2 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}
