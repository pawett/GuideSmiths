using Xunit;
using MartianRobots.Application;
using MartianRobots.Domain;
using System.Linq;
using System;

namespace Tests
{
    public class IntegrationTests
    {

        [Fact]
        public void WhenInputIsInvalidThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => InputHelper.ReadInputData(@"51 3
3 2 N
FRRFLLFFRRFLL"));

            Assert.Throws<ArgumentException>(() => InputHelper.ReadInputData(@"5 3
3000 2 N
FRRFLLFFRRFLL"));

            Assert.Throws<ArgumentException>(() => InputHelper.ReadInputData(@"5 3
3 2 N
FRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLRRRLLLFFFFFFFF"));
        }

        [Fact]
        public void WhenRobotMovesOnTheGridTheEndPositionIsCorrect()
        {
            var instructions = InputHelper.ReadInputData(@"5 3
1 1 E
RFRFRFRF");
            MissionControlService service = new MissionControlService(instructions.UpperRightCoordinate);

            var results = service.ExecuteMission(instructions.RobotInstructions);
            Assert.Equal(RobotStatus.Ok, results.First().Status);
            Assert.Equal(1, results.First().Position.Coordinates.X);
            Assert.Equal(1, results.First().Position.Coordinates.Y);
            Assert.Equal(Orientation.E, results.First().Position.Orientation);
        }

        [Fact]
        public void WhenRobotMovesOffTheGridItsStatusIsLost()
        {
            var instructions = InputHelper.ReadInputData(@"5 3
3 2 N
FRRFLLFFRRFLL");
            MissionControlService service = new MissionControlService(instructions.UpperRightCoordinate);

            var results = service.ExecuteMission(instructions.RobotInstructions);
            Assert.Equal(RobotStatus.Lost, results.First().Status);
        }

        [Fact]
        public void WhenRobotsFallsOffTheGridAScentIsCreatedInTheLastPosition()
        {
            var instructions = InputHelper.ReadInputData(@"5 3
3 2 N
FRRFLLFFRRFLL");
            MissionControlService service = new MissionControlService(instructions.UpperRightCoordinate);

            var results = service.ExecuteMission(instructions.RobotInstructions);
            
            Assert.True(service.Surface.PositionHasScent(new Coordinates(3,3)));
        }

         [Fact]
        public void WhenMovingOffTheGridFromPositionWithScentRobotIgnoresTheInstruction()
        {
            MissionControlService service = new MissionControlService(new Coordinates(5, 3));
            var instructionsLost = InputHelper.ReadInputData(@"5 3
0 3 W
LLFFFLFLFL");

            var results = service.ExecuteMission(instructionsLost.RobotInstructions);
            Assert.Equal(RobotStatus.Lost, results.First().Status);

            var instructionsWithScent = InputHelper.ReadInputData(@"5 3
0 3 W
LLFFFLFLFL");
            service = new MissionControlService(new Coordinates(5, 3));
            service.Surface.AddScent(new Coordinates(3,3));
            var resultsIgnore = service.ExecuteMission(instructionsWithScent.RobotInstructions);
            Assert.Equal(RobotStatus.Ok, resultsIgnore.Last().Status);
            Assert.Equal(2, resultsIgnore.Last().Position.Coordinates.X);
            Assert.Equal(3, resultsIgnore.Last().Position.Coordinates.Y);
            Assert.Equal(Orientation.S, resultsIgnore.Last().Position.Orientation);
        }
    }
}
