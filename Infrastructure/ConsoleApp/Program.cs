using System;

using MartianRobots.Application;


namespace MartianRobots.Infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputDataRetriever inputDataSource = new ConsoleInput();
            InputData inputData;
            try
            {
                inputData = inputDataSource.GetInputData();
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
           
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex}");
            }
            
            
        }

    }
}
