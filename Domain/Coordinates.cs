namespace MartianRobots.Domain
{
    public class Coordinates
    {
        public int X {get; private set;}
        public int Y {get;private set;}
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveNorth()
        {
            Y++;
        }
        public void MoveSouth()
        {
            Y--;
        }
        public void MoveEast()
        {
            X++;
        }
        public void MoveWest()
        {
            X--;
        }
    }
}