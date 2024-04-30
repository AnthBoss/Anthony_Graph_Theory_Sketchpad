// <copyright file="Graph.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GraphTheorySketchPad.Graphing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The main public class of Graph.
    /// </summary>
    public class Graph
    {
        private List<Edge> edges; // The list of all of the graph's edges.
        private Vertex currentVertex; // The current vertex that the user selected.
        private List<Vertex> vertices; // The list of all graph's verticies.
        private List<Edge> currentEdges; // The current list of edges that the user selected.
        private bool hasCurrentVertex; // A bool check to see whether a Vertex is selected.

        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        public Graph()
        {
            this.edges = new List<Edge>();
            this.currentEdges = new List<Edge>();
            this.vertices = new List<Vertex>();
            this.hasCurrentVertex = false;
        }

        /// <summary>
        /// Gets the vertices.
        /// </summary>
        public List<Vertex> GetVertices
        {
            get
            {
                return this.vertices;
            }
        }

        /// <summary>
        /// Gets the edges.
        /// </summary>
        public List<Edge> GetEdges
        {
            get
            {
                return this.edges;
            }
        }

        /// <summary>
        /// Gets the current vertex.
        /// </summary>
        public Vertex GetCurrentVertex
        {
            get
            {
                return this.currentVertex;
            }
        }

        /// <summary>
        /// Gets the current edges.
        /// </summary>
        public List<Edge> GetCurrentEdges
        {
            get
            {
                return this.currentEdges;
            }
        }

        /// <summary>
        /// Updates the selected vertex.
        /// </summary>
        /// <param name="v">target vertex</param>
        /// <param name="value">wether to deselect or select the vertex</param>
        public void UpdateSelectedVertex(Vertex v, bool value)
        {
            if (!hasCurrentVertex && value)
            {
                v.IsCurrent = true;
                this.currentVertex = v;
                this.hasCurrentVertex = true;
            }
            else if (!value)
            {
                v.IsCurrent = false;
                this.currentVertex = null;
                this.hasCurrentVertex = false;
            }
        }

        /// <summary>
        /// Select a new edge.
        /// </summary>
        /// <param name="e">edge to be selected</param>
        public void AddSelectedEdge(Edge e)
        {
            currentEdges.Add(e);
        }

        /// <summary>
        /// Deselects an edge.
        /// </summary>
        /// <param name="e">edge to deselect</param>
        public void DeselectEdge(Edge e)
        {
            currentEdges.Remove(e);
        }

        /// <summary>
        /// Adds a new vertex to the graph.
        /// </summary>
        /// <param name="v"> vertex to add.</param>
        public void AddVertex(Vertex v)
        {
            vertices.Add(v);
        }

        public void AddEdge(Vertex from, Vertex to, Color color, int width)
        {
            if (from == null || to == null) return;

            // Check if an edge between these vertices already exists
            Edge existingEdge = from.GetConnectedEdges.Find(e => e.Vertex2 == to);
            if (existingEdge != null)
            {
                // Handle parallel edges
                from.AddParallelEdge();
                to.AddParallelEdge();
                var parallelEdge = new Edge(from, to, width, from.GetParallelEdges, color);
                edges.Add(parallelEdge);
                from.GetConnectedEdges.Add(parallelEdge);
                to.GetConnectedEdges.Add(parallelEdge);
            }
            else
            {
                var newEdge = new Edge(from, to, width, color);
                edges.Add(newEdge);
                from.GetConnectedEdges.Add(newEdge);
                to.GetConnectedEdges.Add(newEdge);

                from.GetNeighbors.Add(to);
                to.GetNeighbors.Add(from);
            }
        }

        public void SelectVertex(Vertex vertex, bool select)
        {
            if (vertex == null) return;

            if (select)
            {
                if (currentVertex == null)
                {
                    vertex.IsCurrent = true;
                    currentVertex = vertex;
                }
            }
            else
            {
                vertex.IsCurrent = false;
                currentVertex = null;
            }
        }

        public void SelectEdge(Edge edge, bool select)
        {
            if (edge == null) return;

            if (select && !currentEdges.Contains(edge))
            {
                currentEdges.Add(edge);
            }
            else if (!select)
            {
                currentEdges.Remove(edge);
            }
        }

        public bool IsBipartite()
        {
            if (HasLoop()) return false;

            foreach (var vertex in vertices)
            {
                vertex.VertexColor = Color.Black;
            }

            var visited = new bool[vertices.Count];
            bool isBipartite = true;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (!visited[i])
                {
                    isBipartite &= PaintGraph(i, Color.Red, visited);
                }
            }

            return isBipartite;
        }

        public int[,] GetAdjacencyMatrix()
        {
            int n = vertices.Count;
            int[,] adjacencyMatrix = new int[n, n];
            int indexX = 0;
            int indexY = 0;
            foreach (Vertex v in vertices)
            {
                indexX = vertices.IndexOf(v);

                foreach (Vertex neighbor in v.GetNeighbors)
                {
                    indexY = vertices.IndexOf(neighbor);
                    adjacencyMatrix[indexX, indexY] = 1;
                }
            }
            return adjacencyMatrix;
        }

        public int GetConnectedComponentCount()
        {
            var visited = new bool[vertices.Count];
            int componentCount = 0;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (!visited[i])
                {
                    PerformDepthFirstSearch(i, visited);
                    componentCount++;
                }
            }

            return componentCount;
        }

        private void PerformDepthFirstSearch(int startIndex, bool[] visited)
        {
            if (startIndex < 0 || startIndex >= vertices.Count || visited[startIndex]) return;

            visited[startIndex] = true;

            var current = vertices[startIndex];
            foreach (var neighbor in current.GetNeighbors)
            {
                int neighborIndex = vertices.IndexOf(neighbor);
                if (neighborIndex >= 0 && !visited[neighborIndex])
                {
                    PerformDepthFirstSearch(neighborIndex, visited);
                }
            }
        }

        private bool PaintGraph(int startIndex, Color color, bool[] visited)
        {
            if (startIndex < 0 || startIndex >= vertices.Count) return false;

            var current = vertices[startIndex];
            if (current.VertexColor == color) return false;

            current.VertexColor = color;
            visited[startIndex] = true;

            var alternateColor = color == Color.Red ? Color.Blue : Color.Red;

            foreach (var neighbor in current.GetNeighbors)
            {
                int neighborIndex = vertices.IndexOf(neighbor);
                if (neighborIndex >= 0 && !visited[neighborIndex])
                {
                    if (!PaintGraph(neighborIndex, alternateColor, visited))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool HasLoop()
        {
            foreach (var edge in edges)
            {
                if (edge.IsLoop) return true;
            }

            return false;
        }
    }
}
