using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Interface
{
    public interface  IRoverUnit
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        string PositionFacing { get; set; }
        IEnumerable<IRoverUnit> Squad { get; set; }

    }
}
