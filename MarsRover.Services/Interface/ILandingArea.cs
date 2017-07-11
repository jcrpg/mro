using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Interface
{
    public interface ILandingArea
    {
        int SizeForWidth { get; set; }
        int SizeForHeight { get; set; }
    }
}
