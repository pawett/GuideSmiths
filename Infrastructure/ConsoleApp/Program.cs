using System;
using System.Text;
using MartianRobots.Application;


namespace MartianRobots.Infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            InputData inputData;

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                var currentLine = string.Empty;
                do
                {
                    currentLine = Console.ReadLine();
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        sb.AppendLine(currentLine);
                    }
                }
                while (!string.IsNullOrEmpty(currentLine));

                try
                {

                    inputData = InputHelper.ReadInputData(sb.ToString().Trim());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid input: {ex}");
                    return;
                }

                try
                {
                    var missionControl = new MissionControlService(inputData.UpperRightCoordinate);
                    var results = missionControl.ExecuteMission(inputData.RobotInstructions);

                    Console.WriteLine(OutputHelper.FormatOutput(results));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex}");
                }
            }
        }
    }
}
