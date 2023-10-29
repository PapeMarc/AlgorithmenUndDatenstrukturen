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
        private string[] pathRegister;

        public Dijkstra(Graph mesh)
        {
            this.graph = mesh;
            this.pathRegister = new string[graph.LengthVertices];
        }

        public char Start { get; set; }
        public char End { get; set; }
    }

    public class Graph
    {
        private List<Vertice> vertices;
        private List<Edge> edges;

        public List<Vertice> Vertices { get => vertices; }
        public List<Edge> Edges { get => edges; }

        public int LengthVertices { get { return vertices.Count; } }
        public int LengthEdges { get { return edges.Count; } }

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
