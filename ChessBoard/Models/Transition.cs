using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBoard.Models
{
    public class Transition
    {
        [Column(TypeName = "nvarchar(31)")]
        public string RegionId1 { get; set; } 
        public Region Region1 { get; set; }
        [Column(TypeName = "nvarchar(31)")]
        public string RegionId2 { get; set; }
        public Region Region2 { get; set; }
        public string[] Factions { get; private set; }
        public float Penalty { get; private set; }
        public bool PermittedForPlayer { get; private set; }

        public Transition(string regionId1, string regionId2, string[] factions, float penalty, bool permittedForPlayer)
        // public Transition((string A, string B) regions, string[] factions, float penalty)
        // public Transition(ValueTuple<string, string> regions, string[] factions, float penalty)
        {
            RegionId1 = regionId1;
            RegionId2 = regionId2;
            Factions = factions;
            Penalty = penalty;
            PermittedForPlayer = permittedForPlayer;
        }

        //public static void TestCreation()
        //{
        //    var v = new Transition(("a", "b"), new string[] { "abs", "dgg" }, 0.4F);
        //}
    }
}
