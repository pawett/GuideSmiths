using System;
using System.Collections.Generic;
using MartianRobots.Domain;

namespace MartianRobots.Application
{
    public class InputData
    {
        public Coordinates UpperRightCoordinate {get;set;}
        public List<RobotInstructions> RobotInstructions {get;set;} = new List<RobotInstructions>();
    }

    public class RobotInstructions
    {
        public Robot Robot {get;set;}
        public List<Instruction> Instructions {get;set;} = new List<Instruction>();
    }
}