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
        public static IComparable[] Sort(IComparable[] toSort)
        {
            Vector2[] smallestUnits;

            //------------------------------------------------------| Init
            if (toSort.Length % 2 == 0)
            {
                smallestUnits = new Vector2[toSort.Length / 2];
            }
            else
            {
                smallestUnits = new Vector2[toSort.Length + 1 / 2];
            }

            IComparable[] output = new IComparable[toSort.Length];

            //------------------------------------------------------| Merge


            //Return Value
            return output;

        }

        private static IComparable[] Merge(IComparable[] A1, IComparable[] A2)
        {
            int max = A1.Length >= A2.Length ? A1.Length : A2.Length;
            IComparable[] returnValue = new IComparable[A1.Length+A2.Length];
            int a1 = 0, a2 = 0;
            for(int i = 0; i < max; i++)
            {
                if (A1[a1].CompareTo(A2[a2]) >= 0)
                {
                    returnValue[i] = A2[i];
                    a2++;
                }
                else
                {
                    returnValue[i] = A1[i];
                    a1++;
                }
            }
            return returnValue;
        }


    }
}
