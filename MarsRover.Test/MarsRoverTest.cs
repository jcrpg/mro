using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Domains;
using MarsRover.Library;
using MarsRover.Services.Interface;


namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest
    {

        [TestMethod]
        public void DeployRoverSquad()
        {
            ILandingArea area = new Plateau("5 5");
            RoverSquad roverSquad = new RoverSquad(area);

            roverSquad.DeployRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployRover("3 3 E", "MMRMMRMRRM");

            foreach(var rover in roverSquad)
            {
                Assert.IsNotNull(rover);

            }

        }
        [TestMethod]
        public void ValidateRoverSquadPositionDirection()
        {
            ILandingArea area = new Plateau("5 5");
            RoverSquad roverSquad = new RoverSquad(area);

            roverSquad.DeployRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployRover("3 3 E", "MMRMMRMRRM");

            IRoverUnit roverOne = roverSquad.Find(r => r.XPosition == 1 && r.YPosition==3 && r.PositionFacing=="N");
            IRoverUnit roverTwo = roverSquad.Find(r => r.XPosition == 5 && r.YPosition==1 && r.PositionFacing=="E");

            Assert.IsNotNull(roverOne);
            Assert.IsNotNull(roverTwo);
        }
    }
}
