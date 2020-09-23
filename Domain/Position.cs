namespace MartianRobots.Domain
{
    public enum Orientation
    {
      N,S,E,W  
    }

    public class Position
    {
        public Coordinates Coordinates { get; private set; }
        public Orientation Orientation { get; private set; }

        public Position(int x, int y, Orientation orientation)
        {
            Coordinates = new Coordinates(x, y);
            Orientation = orientation;
        }

        public void SetOrientation(Orientation orientation)
        {
            Orientation = orientation;
        }
    }
}