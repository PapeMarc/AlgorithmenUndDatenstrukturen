using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Stopwatch sw = new Stopwatch();
            sw.Start();
            IComparable[] toSort = new IComparable[100000];
            Random r = new Random();
            for(int i = 0; i < toSort.Length; i++)
            {
                toSort[i] = r.Next(19999) + 1;
            }
            sw.Stop();
            

            //---------------------------------------------Heapsort--|
                sw.Restart();
                toSort = HeapSort.Sort(toSort.ToArray());
                sw.Stop();
            //-------------------------------------------------------|

            Console.WriteLine("Millisecounds till completion: " + sw.ElapsedMilliseconds);
            /*for (int i = 0; i < toSort.Length; i++)
            {
                Console.Write(Convert.ToInt32(toSort[i]) + " ");
            }*/

            //Console.ReadKey();

            // Dijkstra
            Graph mesh = new Graph();
            mesh.AddVertice('A');
            mesh.AddVertice('B');
            mesh.AddVertice('C');
            mesh.AddVertice('D');

            mesh.EstablishEdge('A', 'B', 2);
            mesh.EstablishEdge('A', 'C', 1);
            mesh.EstablishEdge('B', 'D', 3);
            mesh.EstablishEdge('C', 'D', 5);

            Dijkstra dijkstra = new Dijkstra(mesh);
            
            dijkstra.Start = 'A';
            dijkstra.End = 'D';

            dijkstra.GetDijkstraRout(0);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

    }
}
