using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoard.Models
{
    public class Transition
    {
        [Column(TypeName = "nvarchar(10)")]
        public string RegionName1 { get; private set; } 
        public Region Region1 { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string RegionName2 { get; private set; }
        public Region Region2 { get; set; }
        public string[] Factions { get; private set; }
        public float Penalty { get; private set; }
        public Transition(string regionName1, string regionName2, string[] factions, float penalty)
        // public Transition((string A, string B) regions, string[] factions, float penalty)
        // public Transition(ValueTuple<string, string> regions, string[] factions, float penalty)
        {
            RegionName1 = regionName1;
            RegionName2 = regionName2;
            Factions = factions;
            Penalty = penalty;
        }

        //public static void TestCreation()
        //{
        //    var v = new Transition(("a", "b"), new string[] { "abs", "dgg" }, 0.4F);
        //}
    }
}
