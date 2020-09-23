using MartianRobots.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Application
{
    public class OutputHelper
    {
        public static string FormatOutput(IEnumerable<Robot> robots)
        {
            var sb = new StringBuilder();
            foreach (var robot in robots)
            {
                var status = "";
                status = robot.Status == RobotStatus.Lost ? "LOST" : "";
                sb.AppendLine($"{robot.Position.Coordinates.X} {robot.Position.Coordinates.Y} {robot.Position.Orientation} {status}");
            }

            return sb.ToString().Trim();
        }
    }
}
