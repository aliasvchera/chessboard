namespace ChessBoard.Models
{
    public class Location
    {
        public int X { get; }
        public int Y { get; }
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            if(obj is Location loc)
            {
                return loc.X == this.X && loc.Y == this.Y;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return X * 5000 + Y;
        }
    }
}
 