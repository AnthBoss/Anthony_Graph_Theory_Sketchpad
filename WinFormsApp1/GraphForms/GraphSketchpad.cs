using GraphTheorySketchPad.Graphing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphTheorySketchPad
{
    public partial class GraphSketchpad : Form
    {
        private Graph graph;
        private Vertex selectedVertex;
        private Edge selectedEdge;

        public GraphSketchpad()
        {
            InitializeComponent();  // Initialize components defined in the designer class
            graph = new Graph();
        }

        private void AddVertexButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var x = random.Next(50, 750);
            var y = random.Next(50, 550);
            var radius = 20;

            var vertex = new Vertex(Guid.NewGuid().ToString(), new Point(x, y), radius);
            graph.GetVertices.Add(vertex);

            UpdateGraphDisplay();
        }

        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            if (graph.GetVertices.Count >= 2)
            {
                var vertex1 = graph.GetVertices[graph.GetVertices.Count - 1];
                var vertex2 = graph.GetVertices[graph.GetVertices.Count - 2];

                var edge = new Edge(vertex1, vertex2, 5);
                graph.GetEdges.Add(edge);

                UpdateGraphDisplay();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedVertex != null)
            {
                graph.GetVertices.Remove(selectedVertex);

                var edgesToRemove = graph.GetEdges.FindAll(edge => edge.Vertex1 == selectedVertex || edge.Vertex2 == selectedVertex);
                foreach (var edge in edgesToRemove)
                {
                    graph.GetEdges.Remove(edge);
                }

                selectedVertex = null;
            }
            else if (selectedEdge != null)
            {
                graph.GetEdges.Remove(selectedEdge);
                selectedEdge = null;
            }

            UpdateGraphDisplay();
        }

        private void GraphPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var clickPoint = new Point(e.X, e.Y);

            selectedVertex = graph.GetVertices.Find(vertex => vertex.IsObject(clickPoint));
            selectedEdge = graph.GetEdges.Find(edge => edge.IsObject(clickPoint));
        }

        private void GraphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedVertex != null)
            {
                // Reposition the vertex
                selectedVertex.Coordinates = new Point(e.X - selectedVertex.GetRadius, e.Y - selectedVertex.GetRadius);

                UpdateGraphDisplay();
            }
        }

        private void GraphPanel_MouseUp(object sender, MouseEventArgs e)
        {
            selectedVertex = null;
        }

        private void UpdateGraphDisplay()
        {
            using (var g = this.graphPanel.CreateGraphics())
            {
                g.Clear(Color.White);

                var pen = new Pen(Color.Black, 2);

                foreach (var edge in graph.GetEdges)
                {
                    edge.Draw(g, pen);
                }

                foreach (var vertex in graph.GetVertices)
                {
                    vertex.Draw(g, pen);
                }

                this.infoLabel.Text = $"Vertices: {graph.GetVertices.Count}, Edges: {graph.GetEdges.Count}";
            }
        }
    }
}