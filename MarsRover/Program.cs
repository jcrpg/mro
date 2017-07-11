using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM".Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var bounds = input[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            var dirs = "NESW"; var magnitudes = new[] { Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(-1, 0) };
            for (int i = 1; i < input.Length; i += 2)
            {
                var start = input[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var x = int.Parse(start[0]); var y = int.Parse(start[1]); var d = dirs.IndexOf(start[2]);
                foreach (var command in input[i + 1])
                    switch (command)
                    {
                        case 'L': d = (--d + magnitudes.Length) % magnitudes.Length; break;
                        case 'R': d = ++d % magnitudes.Length; break;
                        default: x = Math.Min(bounds[0], Math.Max(0, x + magnitudes[d].Item1)); y = Math.Min(bounds[1], Math.Max(0, y + magnitudes[d].Item2)); break;
                    }
                Console.WriteLine(x + " " + y + " " + dirs[d]);
            }
            Console.ReadKey();
        }
    }
}
