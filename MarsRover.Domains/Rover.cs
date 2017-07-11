using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Services.Interface;
using System.Text.RegularExpressions;

namespace MarsRover.Domains
{
    public class Rover : IRoverUnit
    {

        public Rover(IEnumerable<IRoverUnit> squad, ILandingArea landingArea, string curPosition, string command)
        {
            Squad = squad;

            ConfigureCommandPosition(curPosition);

            if (!isValidPosition(landingArea)) throw new Exception("Invalid position");

            CommandRoverMovement(command);

        }
        private void ConfigureCommandPosition(string RoverPosition)
        {
            Regex reg = new Regex(Constants.RegRoverPosition);

            if (!reg.IsMatch(RoverPosition))
                throw new Exception("incorrect rover coordinates");

            string[] array = RoverPosition.Split(Constants.Seperator);

            if (array.Length != 3)
                throw new Exception("Missing Rover position or command");


            XPosition = Convert.ToInt32(array[0]);
            YPosition = Convert.ToInt32(array[1]);
            PositionFacing = (array[2]);

        }

        private void CommandRoverMovement(string commands)
        {
            Regex reg = new Regex(Constants.RegRoverMovement);

            if (!reg.IsMatch(commands))
                throw new Exception("incorrect rover movement");

            foreach (char command in commands)
            {
                switch (command.ToString())
                {
                    case Constants.Commands.MoveForward:
                        GoForward();
                        break;
                    default:
                        TurnAround(command.ToString());
                        break;
                }
            }
        }

        private bool isValidPosition(ILandingArea area)
        {
            return (XPosition >= 0) && (XPosition < area.SizeForWidth) && (YPosition >= 0) && (YPosition < area.SizeForHeight);
        }

        public void GoForward()
        {
            switch (PositionFacing)
            {
                case Constants.Facing.East:
                    XPosition += 1;
                    break;
                case Constants.Facing.South:
                    YPosition -= 1;
                    break;
                case Constants.Facing.West:
                    XPosition -= 1;
                    break;
                case Constants.Facing.North:
                    YPosition += 1;
                    break;
                default:
                    throw new Exception("Cannot compute forward command");
            }
        }

        public void TurnAround(string direction)
        {
            switch (direction)
            {
                case Constants.Commands.TurnLeft:
                    TurnLeft();
                    break;
                case Constants.Commands.TurnRight:
                    TurnRight();
                    break;
                default:
                    throw new Exception("Cannot compute turning position");
            }
        }
        private void TurnLeft()
        {
            switch (PositionFacing)
            {
                case Constants.Facing.North:
                    PositionFacing = Constants.Facing.West;
                    break;

                case Constants.Facing.West:
                    PositionFacing = Constants.Facing.South;
                    break;

                case Constants.Facing.South:
                    PositionFacing = Constants.Facing.East;
                    break;

                case Constants.Facing.East:
                    PositionFacing = Constants.Facing.North;
                    break;
            }
        }


        private void TurnRight()
        {
            switch (PositionFacing)
            {
                case Constants.Facing.North:
                    PositionFacing = Constants.Facing.East;
                    break;

                case Constants.Facing.East:
                    PositionFacing = Constants.Facing.South;
                    break;

                case Constants.Facing.South:
                    PositionFacing = Constants.Facing.West;
                    break;

                case Constants.Facing.West:
                    PositionFacing = Constants.Facing.North;
                    break;
            }
        }

        public int XPosition { get; set ; }
        public int YPosition { get ; set ; }
        public string PositionFacing { get; set ; }
        public IEnumerable<IRoverUnit> Squad { get ; set ; }
    }
}
