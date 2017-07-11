using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Services.Interface;
using MarsRover.Domains;
using System.Text.RegularExpressions;

namespace MarsRover.Domains
{
    public class Plateau : ILandingArea
        
    {

        public Plateau(int x, int y)
        {
            SizeForWidth = x;
            SizeForHeight = y;
        }

        public Plateau(string plateauPosition)
        {
            if (plateauPosition.Length == 0)
                throw new Exception("Plateau Position is empty");

            ConfigureCommandPosition(plateauPosition);
        }

        public int SizeForWidth { get; set; }
        public int SizeForHeight { get ; set ; }

        private void ConfigureCommandPosition(string plateauPosition)
        {
            Regex reg = new Regex(Constants.RegPosition);
            if (!reg.IsMatch(plateauPosition))
                throw new Exception("incorrect coordinates input");

            string[] array = plateauPosition.Split(Constants.Seperator);

            if (array.Length!=2)
                throw new Exception("Landing position is incorrect ");


            this.SizeForWidth = Convert.ToInt32(array[0]);
            this.SizeForHeight = Convert.ToInt32(array[1]);

        }
    }
}
