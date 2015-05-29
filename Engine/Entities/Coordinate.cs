namespace Engine.Entities
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Match(Coordinate other)
        {
            return ((X == other.X) && (Y == other.Y));
        }
    }
}
