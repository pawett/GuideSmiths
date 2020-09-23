namespace MartianRobots.Domain
{
    public class ForwardMovement : IRobotMovementCommand
    {
        private Robot _robot;
        private Surface _surface;
        public ForwardMovement(Robot robot, Surface surface)
        {
            _robot = robot;
            _surface = surface;
        }
        public Robot Execute()
        {
            Coordinates newPosition = new Coordinates(_robot.Position.Coordinates.X, _robot.Position.Coordinates.Y);

            switch (_robot.Position.Orientation)
            {
                case Orientation.N:
                    newPosition.MoveNorth();
                    break;
                case Orientation.S:
                    newPosition.MoveSouth();
                    break;
                case Orientation.W:
                    newPosition.MoveWest();
                    break;
                case Orientation.E:
                    newPosition.MoveEast();
                    break;
            }

            if (_surface.IsValidPosition(newPosition))
            {
                _robot.MoveForward();
            }
            else if (_surface.PositionHasScent(_robot.Position.Coordinates))
            {
                //Movement to not valid position from one with scent, ignore movement
            }
            else
            {
                _robot.SetLostStatus();
            }

            return _robot;
        }
    }
}