using System.Collections.Generic;
using MartianRobots.Domain;

namespace MartianRobots.Application
{
    public class MissionControlService
    {
        public Surface Surface {get; private set;}

        public MissionControlService(Coordinates upperRight)
        {
            Surface = new Surface(upperRight);
        }

        public IEnumerable<Robot> ExecuteMission(List<RobotInstructions> instructions)
        {
            var results = new List<Robot>();
            foreach (var instruction in instructions)
            {
                results.Add(ExecuteInstructions(instruction.Robot, instruction.Instructions));
            }

            return results;
        }

        private Robot ExecuteInstructions(Robot robot, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                robot = RobotCommandsFactory.GetComand(instruction, robot, Surface)
                .Execute();
                
                if (robot.Status == RobotStatus.Lost)
                {
                    Surface.AddScent(robot.Position.Coordinates);
                    return robot;
                }
            }
            
            return robot;
        }
    }
}