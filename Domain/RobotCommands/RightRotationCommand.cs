namespace MartianRobots.Domain
{


    public class RightRotationCommand : IRobotMovementCommand
    {
        private Robot _robot;
        public RightRotationCommand(Robot robot)
        {
            _robot = robot;
        }

        public Robot Execute()
        {
            _robot.RotateRight();
            return _robot;
        }
    }
}