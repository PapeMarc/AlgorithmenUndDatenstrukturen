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
        private Graph graph;
        private string[][] pathRegister;

        public Dijkstra(Graph mesh)
        {
            this.graph = mesh;
            this.pathRegister = new string[graph.Length][];
        }

        public char Start { get; set; }
        public char End { get; set; }

        public /*Array*/void GetDijkstraRout(float startCosts)
        {
            if(Start == 0 | End == 0)
            {
                throw new Exception("No Start or Endpoint was set.");
            }

            int currentCheck = graph.Vertices.FindIndex(v => v.Ident == Start);

            for(int i = 0; i < pathRegister.Length; i++) // check every Vertice
            {
                for(int j = 0; j < pathRegister.Length; j++) // check all Edges and new Connections for Registery
                {
                    if(j == currentCheck & i == 0)
                    {
                        pathRegister[i][j] = graph.Vertices[j].Ident + "/" + 0;
                    }
                    else
                    {
                        List<Edge> connections = graph.Edges.FindAll(edge => edge.From == graph.Vertices[currentCheck].Ident | edge.To == graph.Vertices[currentCheck].Ident);
                        if(connections.Count > 0)
                        {
                            for(int k = 0; k < connections.Count; k++) // for each Connection
                            {
                                // Getting Target Vertice of Edge
                                char connectionTarget = connections[k].To;
                                if (connectionTarget == currentCheck) { connectionTarget = connections[k].From; }

                                int registerytIndex = graph.Vertices.FindIndex(v => v.Ident.Equals(connectionTarget));

                                if(pathRegister[i][registerytIndex] == null)
                                {
                                    pathRegister[i][registerytIndex] = connectionTarget + "/" + connections[k].Weight;
                                }
                                else if (float.Parse(pathRegister[i][registerytIndex].Split('/')[1]) > connections[k].Weight)
                                {
                                    pathRegister[i][registerytIndex] = connectionTarget + "/" + connections[k].Weight;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public class Graph
    {
        private List<Vertice> vertices;
        private List<Edge> edges;

        public List<Vertice> Vertices { get => vertices; }
        public List<Edge> Edges { get => edges; }

        public int Length { get { return vertices.Count; } }

        public void AddVertice(char ident)
        {
            if (vertices.Find(v => v.Ident.Equals(ident)) is null){
                vertices.Add(new Vertice(ident));
                return;
            }
            throw new Exception("Tried to add a Vertice, that already exists.");
        }

        public void EstablishEdge(char identFrom, char identTo, float weight)
        {
            Edge candidate = edges.Find(e => e.From == identFrom & e.To == identTo);
            if (candidate != null)
            {
                candidate.Weight = weight;
                return;
            }
            else
            {
                edges.Add(new Edge(identFrom, identTo,weight));
                return;
            }
        }
    }

    public class Vertice
    {
        private char ident;
        public char Ident { get => ident; }
        public Vertice(char ident)
        {
            this.ident = ident;
        }
    }

    public class Edge
    {
        private char from, to;

        public char From { get => from;}
        public char To { get => to;}

        public float Weight { get; set; }

        public Edge(char from, char to, float weight)
        {
            this.from = from;
            this.to = to;
            this.Weight = weight;
        }
    }
}
