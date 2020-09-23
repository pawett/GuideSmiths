using System.Collections.Generic;
using MartianRobots.Application;
using System;
using System.Text;

namespace MartianRobots.Infrastructure
{
    public class ConsoleInput : IInputDataRetriever
    {
        public InputData GetInputData()
        {
            //var surfaceDimensions = Console.ReadLine();
            string currentLine = String.Empty;
            StringBuilder sb = new StringBuilder();
            while(true)
            {
                do
                {
                    currentLine = Console.ReadLine();
                    Console.WriteLine($"Line readed {currentLine}");
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        sb.AppendLine(currentLine);
                    }
                    else
                    {
                        Console.WriteLine("No more lines detected");
                    }

                }
                while (!string.IsNullOrEmpty(currentLine));
                Console.WriteLine("Data retrieved from consoleinput:");
                Console.WriteLine(sb.ToString().Trim());

                return InputHelper.ReadInputData(sb.ToString().Trim());
            }
          
        }
    }
}