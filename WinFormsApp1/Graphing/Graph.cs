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
    }
}
