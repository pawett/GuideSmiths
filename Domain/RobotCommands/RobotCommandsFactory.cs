using System;
namespace MartianRobots.Domain
{
    public static class RobotCommandsFactory
    {
        public static IRobotMovementCommand GetComand(Instruction instruction, Robot robot, Surface surface)
        {
            switch (instruction)
            {
                case Instruction.F:
                    return new ForwardMovement(robot, surface);
                case Instruction.L:
                    return new LeftRotationCommand(robot);
                case Instruction.R:
                    return new RightRotationCommand(robot);
                default:
                throw new ArgumentException($"No implementation found for instruction {instruction}");
            }
        }
    }
}