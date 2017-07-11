using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Services.Interface;

namespace MarsRover.Domains
{
    public class RoverSquad:List<IRoverUnit>
    {
        public RoverSquad(ILandingArea area)
        {
            _landingArea = area;
        }

        public void DeployRover(string landingPosition, string command)
        {
            Add(new Rover(this, _landingArea, landingPosition, command));
        }

        public ILandingArea _landingArea { get; set; }

    }
}
