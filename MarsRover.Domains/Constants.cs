using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domains
{
    public class Constants
    {

        public const char Seperator = ' ';
        public const string RegPosition = "^[0-9]+ [0-9]+$";
        public const string RegRoverPosition = "^[0-9]+ [0-9]+ [NESW]$";
        public const string RegRoverMovement = "^[LRM]+$";

        public static class Facing
        {
            public const string North = "N";
            public const string East = "E";
            public const string South = "S";
            public const string West = "W";
        }
        public static class Commands
        {
            public const string MoveForward = "M";
            public const string TurnLeft = "L";
            public const string TurnRight = "R";
        }

    }
}
