using System;
using System.Collections.Generic;

namespace ChessBoard.Models
{
    public interface IArmy
    {
        public List<Tuple<int, int>> FindPath(Tuple<int, int> target);
    }
}
