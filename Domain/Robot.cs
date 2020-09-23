using System;
namespace MartianRobots.Domain
{
    public enum RobotStatus
    {
       Lost,
       Ok
    }
    public class Robot
    {
        public Robot(Position position)
        {
            Position = position;
            Status = RobotStatus.Ok;
        }

        public Position Position {get; private set;}
        public RobotStatus Status {get; private set;}  

        public void SetPosition(int x, int y)
        {
            Position = new Position(x, y, Position.Orientation);
        }

        public void SetLostStatus()
        {
            Status = RobotStatus.Lost;
        }

        public void MoveForward()
        {
            switch (Position.Orientation)
            {
                case Orientation.N:
                    Position.Coordinates.MoveNorth();
                    break;
                case Orientation.S:
                    Position.Coordinates.MoveSouth();
                    break;
                case Orientation.W:
                    Position.Coordinates.MoveWest();
                    break;
                case Orientation.E:
                    Position.Coordinates.MoveEast();
                    break;
            }
        }

        public void RotateLeft()
        {
            switch (Position.Orientation)
            {
                case Orientation.N:
                    Position.SetOrientation(Orientation.W);
                    break;
                case Orientation.S:
                    Position.SetOrientation(Orientation.E);
                    break;
                case Orientation.W:
                    Position.SetOrientation(Orientation.S);
                    break;
                case Orientation.E:
                    Position.SetOrientation(Orientation.N);
                    break;
            }
        }

        public void RotateRight()
        {
            switch (Position.Orientation)
            {
                case Orientation.N:
                    Position.SetOrientation(Orientation.E);
                    break;
                case Orientation.S:
                    Position.SetOrientation(Orientation.W);
                    break;
                case Orientation.W:
                    Position.SetOrientation(Orientation.N);
                    break;
                case Orientation.E:
                    Position.SetOrientation(Orientation.S);
                    break;
            }
        }
    }
}