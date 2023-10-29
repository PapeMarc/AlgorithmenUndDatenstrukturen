using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Dijkstra
    {
        /* A B C D Z
        A->B&C
        B->A&Z
        C->A&D
        D->C&Z
        */

        private char start, target;
        private Graph graph;

        private Vertice currentFocus;
        private List<Vertice> toCheckNext;

        private List<Vertice> checkedAlready;

        private Dictionary<char,string> finalRoutes;

        public Dijkstra(Graph g)
        {
            this.graph = g;
        }

        public string GetRout(char Start, char Target)
        {
            this.start = Start;
            this.target = Target;
            
            finalRoutes = new Dictionary<char,string>();
            for(int i = 0; i < graph.Length; i++)
            {
                finalRoutes.Add(graph.Storage[i].Ident, "notAquired");
            }

            // Wurde der Weg schonmal ermittelt, wird auf eine erneute Pruefung verzichtet.
            if (finalRoutes[Target] != "notAquired")
            {
                return finalRoutes[Target];
            }

            finalRoutes[Start] = "S0";
            CheckVertices(Start);
        }

        private void CheckVertices(char toCheck)
        {
            currentFocus = graph.Storage.Find(v => v.Ident == toCheck);
            List<string> neighbours = new List<string>();
            foreach(KeyValuePair<char,float> kvp in currentFocus.ConnectedVertices)
            {
                neighbours.Add("" + kvp.Key + kvp.Value);
            }

            foreach(string s in neighbours)
            {

                if (finalRoutes.ContainsKey(s[0]))
                {
                    if (finalRoutes[s[0]])
                }
                else
                {
                    finalRoutes[s[0]] = ;
                }
            }

        }
    }

    public class Graph
    {
        private List<Vertice> graph; 
        public Graph()
        {
            graph = new List<Vertice>();
        }

        public int Length { get { return graph.Count; } }

        public List<Vertice> Storage => graph;

        public void AddVertice(char ident)
        {
            graph.Add(new Vertice(ident));
        }

        public void ConnectVertices(float costs, char verticeIdent_1, char verticeIdent_2)
        {
            graph.Find(v => v.Ident == verticeIdent_1).AddConnectedVertice(verticeIdent_2, costs);
            graph.Find(v => v.Ident == verticeIdent_2).AddConnectedVertice(verticeIdent_1, costs);
        }
    }

    public class Vertice // Klasse Edge mit from, to und den costs ist besser, nachtragen!
    {
        private Dictionary<char,float> connectedVertices; // Identifier, Edge-weight
        private char ident;

        public char Ident { get { return ident; } }
        public Dictionary<char,float> ConnectedVertices {  get { return connectedVertices; } }

        public Vertice(char identifier)
        {
            this.connectedVertices = new Dictionary<char, float>();
            this.ident = identifier;
        }

        public void AddConnectedVertice(char ident, float costs)
        {
            connectedVertices.Add(ident, Math.Abs(costs));
        }
    }
}
