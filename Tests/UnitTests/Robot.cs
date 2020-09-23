using Xunit;
using MartianRobots.Domain;

namespace Tests
{
    public class RobotTest
    {
        [Fact]
        public void WhenRobotMovesForwardItDoesSoInTheCorrectOrientation()
        {
            var robot = new Robot(new Position(1, 1, Orientation.N));
            robot.MoveForward();
            Assert.True(robot.Position.Coordinates.X == 1 && robot.Position.Coordinates.Y == 2);

            robot.RotateRight();
            robot.MoveForward();
            Assert.True(robot.Position.Coordinates.X == 2 && robot.Position.Coordinates.Y == 2);
            Assert.Equal(Orientation.E, robot.Position.Orientation);
            
            robot.RotateRight();
            robot.MoveForward();
            Assert.True(robot.Position.Coordinates.X == 2 && robot.Position.Coordinates.Y == 1);
            Assert.Equal(Orientation.S, robot.Position.Orientation);
            
            robot.RotateRight();
            robot.MoveForward();
            Assert.True(robot.Position.Coordinates.X == 1 && robot.Position.Coordinates.Y == 1);
            Assert.Equal(Orientation.W, robot.Position.Orientation);

            robot.RotateLeft();
            robot.MoveForward();
            Assert.True(robot.Position.Coordinates.X == 1 && robot.Position.Coordinates.Y == 0);
            Assert.Equal(Orientation.S, robot.Position.Orientation);
        }
    }
}
