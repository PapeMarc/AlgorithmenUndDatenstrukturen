﻿using System;
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
            for(int i = 0; i < pathRegister.Length; i++) { pathRegister[i] = new string[graph.Length]; }
        }

        public char Start { get; set; }
        public char End { get; set; }

        public /*string[]*/void GetDijkstraRout(float startCosts)
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
                        pathRegister[i][j] = graph.Vertices[j].Ident + "/" + startCosts;
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
                                if (connectionTarget == graph.Vertices[currentCheck].Ident) { connectionTarget = connections[k].From; }

                                int registerytIndex = graph.Vertices.FindIndex(v => v.Ident.Equals(connectionTarget));

                                if(pathRegister[i][registerytIndex] == null) // If there is not any connection registered
                                {
                                    pathRegister[i][registerytIndex] = graph.Vertices[currentCheck].Ident + "/" + connections[k].Weight;
                                }
                                else if (float.Parse(pathRegister[i][registerytIndex].Split('/')[1]) > connections[k].Weight) // If there is already a connection
                                {
                                    pathRegister[i][registerytIndex] = graph.Vertices[currentCheck].Ident + "/" + connections[k].Weight;
                                }
                                // A missing Connection is usually registered with the Symbol of infinity. In my Code it's just -1.
                            }

                            /*Get the minimum of our registry in the current iteration*/
                            int min = -1;
                            for (int k = 0; k < pathRegister[i].Length; k++)
                            {
                                if (k != currentCheck) // Don't check the iteration-value
                                {
                                    if(min == -1) // Generate a random Index at the first iteration
                                    {
                                        while (min == -1 || min == currentCheck) 
                                        {
                                            min = new Random().Next(graph.Length);
                                            if (pathRegister[i][min] == null || min == k)
                                            {
                                                min = -1;
                                            }
                                        }
                                    }


                                    // if the current value on index k is smaller than the value at our current min, our min get's updated.
                                    float kw = float.PositiveInfinity, mw = float.PositiveInfinity;
                                    if (pathRegister[i][k] != null)
                                        kw = float.Parse(pathRegister[i][k].Split('/')[1]);

                                    if(pathRegister[i][min] != null)
                                        mw = float.Parse(pathRegister[i][min].Split('/')[1]);

                                    if (kw < mw)
                                    {
                                        min = k;
                                    }
                                }
                            }
                            currentCheck = min;
                        }
                    }
                }
            }

            return;
        }
    }

    public class Graph
    {
        private List<Vertice> vertices;
        private List<Edge> edges;

        public List<Vertice> Vertices { get => vertices; }
        public List<Edge> Edges { get => edges; }

        public int Length { get { return vertices.Count; } }

        public Graph()
        {
            vertices = new List<Vertice>();
            edges = new List<Edge>();
        }

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
