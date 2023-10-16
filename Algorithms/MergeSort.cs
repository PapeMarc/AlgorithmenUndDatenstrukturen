using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MergeSort
    {
        private static IComparable[] input;
        private static Vector2[] smallestUnits;

        private static void LocalInit(IComparable[] toSort)
        {
            input = toSort;
            if(input.Length % 2 == 0)
            {
                smallestUnits = new Vector2[input.Length / 2];
            }
            else
            {
                smallestUnits = new Vector2[input.Length+1 / 2];
            }
        }


    }
}
