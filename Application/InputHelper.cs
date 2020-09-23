using System;
using MartianRobots.Domain;

namespace MartianRobots.Application
{
    public static class InputHelper
    {
        private static void CheckCoordinateConstraints(int coordinate)
        {
            if (coordinate > 50)
            {
                throw new ArgumentException("The maximum value for each coordinate is 50");
            }
        }
        public static InputData ReadInputData(string data)
        {     
            var lines = data.Split('\n');

            var upperRightCoordinate = lines[0].Split(' ');
            var upperRightCoordinateX = int.Parse(upperRightCoordinate[0]);
            var upperRightCoordinateY = int.Parse(upperRightCoordinate[1]);
            CheckCoordinateConstraints(upperRightCoordinateX);
            CheckCoordinateConstraints(upperRightCoordinateY);
            var upperRightCoordinatePosition = new Coordinates(upperRightCoordinateX, upperRightCoordinateY);

            var inputData = new InputData();
            inputData.UpperRightCoordinate = upperRightCoordinatePosition;

            for (int i = 1; i < lines.Length; i++)
            {
                var robotInstructions = new RobotInstructions();
                var position = lines[i].Split(' ');
                var x = int.Parse(position[0].Trim());
                var y = int.Parse(position[1].Trim());

                CheckCoordinateConstraints(x);
                CheckCoordinateConstraints(y);

                var orientation = (Orientation)Enum.Parse(typeof(Orientation), position[2].Trim());
                var robot = new Robot(new Position(x, y, orientation));
                robotInstructions.Robot = robot;
                i++;
                
                var instructionLine = lines[i].Trim();
                
                if (instructionLine.Length >= 100)
                {
                    throw new ArgumentException("Instruction line lenght is bigger than 100 characters");
                }

                foreach (var instructionChar in instructionLine)
                {
                    if (Enum.TryParse<Instruction>(instructionChar.ToString(), out var instruction))
                    {
                        robotInstructions.Instructions.Add(instruction);
                    }
                }

                inputData.RobotInstructions.Add(robotInstructions);
            }

            return inputData;
        }
    }
}
