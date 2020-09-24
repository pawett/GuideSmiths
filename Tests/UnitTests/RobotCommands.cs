using Xunit;
using MartianRobots.Domain;

namespace Tests
{
    public class RobotCommandsTest
    {
        [Fact]
        public void WhenCommandFactoryIsInvokedReturnsTheCorrectCommandImplementation()
        {
            var surface = new Surface(new Coordinates(5, 5));
            var robot = new Robot(new Position(1, 1, Orientation.E));
            var command = RobotCommandsFactory.GetComand(Instruction.F, robot, surface);
            Assert.IsType<ForwardMovement>(command);

            command = RobotCommandsFactory.GetComand(Instruction.L, robot, surface);
            Assert.IsType<LeftRotationCommand>(command);

            command = RobotCommandsFactory.GetComand(Instruction.R, robot, surface);
            Assert.IsType<RightRotationCommand>(command);
        }
    }
}
