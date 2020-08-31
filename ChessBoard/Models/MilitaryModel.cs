using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBoard.Models
{
    public class MilitaryModel
    {
        public IEnumerable<Fortress> Fortresses { get; set; }
        public IEnumerable<Army> Armies { get; set; }
    }
}
