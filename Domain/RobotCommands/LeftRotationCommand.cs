namespace MartianRobots.Domain
{
    public class LeftRotationCommand : IRobotMovementCommand
    {
        private Robot _robot;
        public LeftRotationCommand(Robot robot)
        {
            _robot = robot;
        }

        public Robot Execute()
        {
            _robot.RotateLeft();
            return _robot;
        }
    }
}