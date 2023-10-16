using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class HeapSort
    {
        public static IComparable[] Sort(IComparable[] array)
        {

            int N = array.Length;

            for (int i = N / 2 - 1; i >= 0; i--)
                Heapify(array, N, i);

            for (int i = N - 1; i > 0; i--)
            {
                IComparable temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }

            return array;
        }

        /// <summary>
        /// To heapify a subtree rooted with node i which is an index in arr[]. 
        /// N is size of heap
        /// </summary>
        /// <param name="array">Array to heapify</param>
        /// <param name="N">Size of the Heap</param>
        /// <param name="i">Root node</param>
        /// <returns></returns>
        private static IComparable[] Heapify(IComparable[] array, int N, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < N && array[l].CompareTo((IComparable)array[largest]) > 0)
                largest = l;

            if (r < N && array[r].CompareTo((IComparable)array[largest]) > 0)
                largest = r;

            if (largest != i)
            {
                IComparable swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                return Heapify(array, N, largest);
            }
            else
            {
                return array;
            }

        }
    }
}
