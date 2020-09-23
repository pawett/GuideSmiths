using System.Collections.Generic;
namespace MartianRobots.Domain
{
    public class Surface
    {
        private Coordinates LowerLeft {get;set;}
        public Coordinates UpperRight {get; private set;}

        public Dictionary<int,HashSet<int>> Scents {get; private set;}

        public Surface(Coordinates upperRight)
        {
            UpperRight = upperRight;
            LowerLeft = new Coordinates(0,0);
            Scents = new Dictionary<int, HashSet<int>>();
        }

        public bool IsValidPosition(Coordinates position)
        {

            if (position.X >= LowerLeft.X && position.X <= UpperRight.X
            && position.Y >= LowerLeft.Y && position.Y <= UpperRight.Y)
            {
                return true;
            }
               

            return false;
        }

        public bool PositionHasScent(Coordinates position)
        {
            return Scents.ContainsKey(position.X) 
                && Scents[position.X].Contains(position.Y);
        }

        public void AddScent(Coordinates position)
        {
            if (!Scents.ContainsKey(position.X))
            {
                Scents.Add(position.X, new HashSet<int>());
            }

            Scents[position.X].Add(position.Y);
        }
    }
}