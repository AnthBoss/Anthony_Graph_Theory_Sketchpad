using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheorySketchPad.Graphing
{
    public class Graph
    {
        private List<Edge> edges; //The list of all of the graph's edges.
        private Vertex currentVertex; // The current vertex that the user selected.
        private List<Vertex> vertices; // The list of all graph's verticies.
        private List<Edge> currentEdges; // The current list of edges that the user selected.
        private bool hasCurrentVertex; // A bool check to see whether a Vertex is selected.

        public Graph()
        {
            edges = new List<Edge>();
            currentEdges = new List<Edge>();
            vertices = new List<Vertex>();
            hasCurrentVertex = false;
        }
    }
}
