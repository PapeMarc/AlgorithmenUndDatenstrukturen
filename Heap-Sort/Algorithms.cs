using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            IComparable[] toSort = new IComparable[128];
            Random r = new Random();
            for(int i = 0; i < toSort.Length; i++)
            {
                toSort[i] = r.Next(256) + 1;
            }

            //---------------------------------------------Heapsort--|
                 toSort = HeapSort.Sort(toSort.ToArray());
            //-------------------------------------------------------|

            for (int i = 0; i < toSort.Length; i++)
            {
                Console.Write(Convert.ToInt32(toSort[i]) + " ");
            }

            Console.ReadKey();
        }

    }
}
