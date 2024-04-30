// <copyright file="GraphSketchpad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GraphTheoristSketchpad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using GraphTheorySketchPad.Graphing;

    /// <summary>
    /// The GraphSketchpad form class.
    /// </summary>
    public partial class SketchPad : Form
    {
        private const int VertexRadius = 12; // default vertex radius
        private const int EdgeWidth = 3; // default edge width

        private Graph graph; // graph holding vertices, edges, and info
        private int vertexCount = 0; // amount of drawn vertices

        private bool moveState; // state of moving vertex
        private bool deleteState; // state of deleting
        private Vertex movingVertex; // the vertex being moved
        private Point lastVertexLocation; // previous moving vertex location

        /// <summary>
        /// Initializes a new instance of the <see cref="SketchPad"/> class.
        /// </summary>
        public SketchPad()
        {
            this.InitializeComponent();
            this.graph = new Graph();
            this.movingVertex = null;
            this.moveState = false;
            this.deleteState = false;

            // stop flickering on panel repaint
            this.DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this.graphPanel, new object[] { true });
        }

        /// <summary>
        /// Function called when the user wants to change the reference paint to a different color.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> Paint event. </param>
        private void PanelPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // draw edges
            if (this.graph.GetEdges != null)
            {
                foreach (Edge edge in this.graph.GetEdges)
                {
                    Pen edgePen;

                    // draw selected edge
                    if (this.graph.GetCurrentEdges.Contains(edge))
                    {
                        edgePen = new Pen(edge.Color, EdgeWidth);
                        edgePen.DashStyle = DashStyle.Dot;
                    }

                    // draw regular edge
                    else
                    {
                        edgePen = new Pen(edge.Color, EdgeWidth);
                        edgePen.DashStyle = DashStyle.Solid;
                    }

                    edge.Draw(g, edgePen);
                    edgePen.Dispose();
                }
            }

            // draw vertices
            if (this.graph.GetVertices != null)
            {
                foreach (Vertex v in this.graph.GetVertices)
                {
                    Pen pen;

                    // add blue outline for selected vertex
                    if (this.graph.GetCurrentVertex == v)
                    {
                        pen = new Pen(Color.DeepSkyBlue, 3);
                        pen.DashStyle = DashStyle.Solid;
                    }

                    // draw regular vertex
                    else
                    {
                        pen = new Pen(Color.Black, 2);
                        pen.DashStyle = DashStyle.Solid;
                    }

                    SolidBrush brush = new SolidBrush(v.VertexColor);
                    v.Draw(g, pen);
                    pen.Dispose();
                }
            }
        }

        /// <summary>
        /// Called when the mouse clicks on the panel.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> the mouse event arguments. </param>
        private void PanelMouseClick(object sender, MouseEventArgs e)
        {
            Point clickPos = e.Location;
            Edge edge = this.TryGetEdge(clickPos); // the clicked edged
            Vertex v = this.TryGetVertex(clickPos); // the clicked vertex

            // right click used for selecting objects
            if (e.Button == MouseButtons.Right)
            {
                // select vertex
                if (v != null)
                {
                    // if selected vertex is already the selected vertex, deselect it
                    if (this.graph.GetCurrentVertex == v)
                    {
                        this.graph.UpdateSelectedVertex(this.graph.GetCurrentVertex, false);
                        this.UpdateGraphInfo();
                        return;
                    }

                    // if selected vertex already exists, deselect it and select new vertex
                    else if (this.graph.GetCurrentVertex != null)
                    {
                        this.graph.UpdateSelectedVertex(this.graph.GetCurrentVertex, false);
                    }

                    this.graph.UpdateSelectedVertex(v, true);
                    this.UpdateGraphInfo();
                    return;
                }

                // select edge
                else if (edge != null)
                {
                    // if selected edge is already selected, deselect it
                    if (this.graph.GetCurrentEdges.Contains(edge))
                    {
                        this.graph.DeselectEdge(edge);
                    }

                    // select edge
                    else
                    {
                        this.graph.AddSelectedEdge(edge);
                    }

                    this.graphPanel.Invalidate();
                    return;
                }
            }

            // if deleting, try delete selected object
            else if (e.Button == MouseButtons.Left && this.deleteState)
            {
                this.TryDeleteObject(clickPos);
                return;
            }

            // Mouse left click for adding and selecting objects
            else if (e.Button == MouseButtons.Left)
            {
                // check if vertex
                if (v != null)
                {
                    // if one vertex is selected, the next selected vertex forms an edge between the two.
                    if (this.graph.GetCurrentVertex != null)
                    {
                        this.graph.AddEdge(this.graph.GetCurrentVertex, v, this.select_color_button.BackColor, EdgeWidth);
                        this.UpdateGraphInfo();
                    }

                    return;
                }

                // check for edges.
                else if (edge != null)
                {
                    // deselect edge if it's already selected.
                    if (this.graph.GetCurrentEdges.Contains(edge))
                    {
                        this.graph.DeselectEdge(edge);
                    }

                    this.graphPanel.Invalidate();
                    return;
                }

                // create new vertex
                else if (v == null)
                {
                    this.vertexCount++;
                    this.graph.AddVertex(new Vertex("V" + this.vertexCount, this.select_color_button.BackColor, clickPos, VertexRadius));
                    this.UpdateGraphInfo();
                    return;
                }
            }
        }

        /// <summary>
        /// Attempt to get the vertex when clicking.
        /// </summary>
        /// <param name="pCurrent"> The current point. </param>
        /// <returns> The vertex if there is one. </returns>
        private Vertex TryGetVertex(Point pCurrent)
        {
            foreach (Vertex v in this.graph.GetVertices)
            {
                if (v.IsObject(pCurrent))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// Attempt to get the edge when clicking.
        /// </summary>
        /// <param name="pCurrent"> The current point that's selected if there is one. </param>
        /// <returns> returns the selected edge if there is one. </returns>
        private Edge TryGetEdge(Point pCurrent)
        {
            foreach (Edge edge in this.graph.GetEdges)
            {
                if (edge.IsObject(pCurrent))
                {
                    return edge;
                }
            }

            return null;
        }

        /// <summary>
        /// Function to try and delete an object if selected.
        /// </summary>
        /// <param name="point"> The point we want to delete if selected. </param>
        private void TryDeleteObject(Point point)
        {
            Vertex v = this.TryGetVertex(point);
            Edge e = this.TryGetEdge(point);

            // Vertex
            if (v != null)
            {
                // remove edges with vertex
                foreach (Edge edge in v.GetConnectedEdges)
                {
                    // update vertex neighbors
                    this.graph.GetVertices.Find(vertex => vertex == edge.Vertex1).GetNeighbors.Remove(edge.Vertex2);
                    this.graph.GetVertices.Find(vertex => vertex == edge.Vertex2).GetNeighbors.Remove(edge.Vertex1);

                    if (this.graph.GetCurrentEdges.Contains(edge))
                    {
                        this.graph.DeselectEdge(edge);
                    }

                    this.graph.GetEdges.Remove(edge);
                }

                if (this.graph.GetCurrentVertex == v)
                {
                    this.graph.UpdateSelectedVertex(v, false);
                }

                v.GetConnectedEdges.Clear();
                this.graph.GetVertices.Remove(v);
                this.vertexCount--;
                this.UpdateGraphInfo();
            }

            // Edge
            else if (e != null)
            {
                if (this.graph.GetCurrentEdges.Contains(e))
                {
                    this.graph.DeselectEdge(e);
                }

                // update vertex neighbors
                this.graph.GetVertices.Find(vertex => vertex == e.Vertex1).GetNeighbors.Remove(e.Vertex2);
                this.graph.GetVertices.Find(vertex => vertex == e.Vertex2).GetNeighbors.Remove(e.Vertex1);
                this.graph.GetEdges.Remove(e);
                e.Vertex1.GetConnectedEdges.Remove(e);
                e.Vertex2.GetConnectedEdges.Remove(e);
                this.UpdateGraphInfo();
            }
        }

        /// <summary>
        /// When the mouse is held down on the graph panel.
        /// </summary>
        /// <param name="sender"> The sender params. </param>
        /// <param name="e"> the mouse event arguments. </param>
        private void GraphPanelMouseDown(object sender, MouseEventArgs e)
        {
            // select vertex to move
            if (e.Button == MouseButtons.Left)
            {
                this.movingVertex = this.TryGetVertex(e.Location);

                if (this.movingVertex != null)
                {
                    this.moveState = true;
                    this.lastVertexLocation = this.movingVertex.Coordinates;
                }
            }
        }

        /// <summary>
        /// When the mouse moves, call this to check if there is currently a vertex being dragged.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> The event arguments. </param>
        private void GraphPanelMouseMove(object sender, MouseEventArgs e)
        {
            // move vertex with mouse
            if (this.moveState && e.Button == MouseButtons.Left)
            {
                Point newPoint = new Point(e.X - this.lastVertexLocation.X, e.Y - this.lastVertexLocation.Y);
                this.lastVertexLocation = e.Location;
                this.movingVertex.MoveCoordinates(newPoint);
                this.graphPanel.Invalidate();
            }
        }

        /// <summary>
        /// When the mouse button is lifted up.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> The event arguments. </param>
        private void GraphPanelMouseUp(object sender, MouseEventArgs e)
        {
            // reset vertex moving attributes
            if (this.moveState && e.Button == MouseButtons.Left)
            {
                this.moveState = false;
                this.movingVertex = null;
            }
        }

        /// <summary>
        /// When the delete button is pressed, call this function.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> the event arguments. </param>
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (!this.deleteState)
            {
                // set button active
                this.deleteButton.BackColor = Color.Red;
                this.deleteState = true;
            }
            else
            {
                // set button inactive
                this.deleteButton.BackColor = SystemColors.ButtonFace;
                this.deleteState = false;
            }
        }

        /// <summary>
        /// Occurs when the change paint button is pressed.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> the event arguments. </param>
        private void PaintButtonClick(object sender, EventArgs e)
        {
            // paint selected objects
            foreach (Edge edge in this.graph.GetCurrentEdges)
            {
                edge.Color = this.select_color_button.BackColor;
            }

            if (this.graph.GetCurrentVertex != null)
            {
                this.graph.GetCurrentVertex.VertexColor = this.select_color_button.BackColor;
                this.graph.UpdateSelectedVertex(this.graph.GetCurrentVertex, false);
            }

            this.graph.GetCurrentEdges.Clear();
            this.graphPanel.Invalidate();
        }

        /// <summary>
        /// When the color select button has been pressed.
        /// </summary>
        /// <param name="sender"> The sender param. </param>
        /// <param name="e"> The event arguments. </param>
        private void SelectColorButtonClick(object sender, EventArgs e)
        {
            // choose color
            this.paint_color_dialog.ShowDialog();
            this.select_color_button.BackColor = this.paint_color_dialog.Color;
        }

        /// <summary>
        /// Call to update the current graph info, this is what makes everything visually work on screen.
        /// </summary>
        private void UpdateGraphInfo()
        {
            this.edge_label.Text = "Edges(m) =  " + this.graph.GetEdges.Count();
            this.vertex_label.Text = "Vertices(n) = " + this.graph.GetVertices.Count();

            if (this.graph.GetCurrentVertex != null)
            {
                this.deg_label.Text = "deg(" + this.graph.GetCurrentVertex.ID + ") = " + this.graph.GetCurrentVertex.GetConnectedEdges.Count();
            }
            else
            {
                this.deg_label.Text = "Degrees(V) = ";
            }

            this.component_label.Text = "Number of Components: " + this.graph.GetConnectedComponentCount();

            this.bipartite_label.Text = "Is Bipartite? ";

            int[,] adjacenyMatrix = this.graph.GetAdjacencyMatrix();
            int dimX = adjacenyMatrix.GetLength(0);
            int dimY = adjacenyMatrix.GetLength(1);
            string[] matrix = new string[dimY];

            for (int y = 0; y < dimY; y++)
            {
                for (int x = 0; x < dimX; x++)
                {
                    matrix[y] += adjacenyMatrix[x, y];
                }
            }

            this.matrix_display.Lines = matrix;
            this.graphPanel.Invalidate();
        }

        /// <summary>
        /// This is called when the "Clear All" button is pressed on the app.
        /// </summary>
        /// <param name="sender"> The sender params. </param>
        /// <param name="e"> The event arguments. </param>
        private void ClearAllButtonClick(object sender, EventArgs e)
        {
            this.graph = new Graph();
            this.movingVertex = null;
            this.moveState = false;
            this.deleteState = false;
            this.vertexCount = 0;
            this.UpdateGraphInfo();
        }

        /// <summary>
        /// When the user presses the button to test whether the current graph is bipartite or not.
        /// </summary>
        /// <param name="sender"> The sender params. </param>
        /// <param name="e"> The event arguments. </param>
        private void BipartiteTestButtonClick(object sender, EventArgs e)
        {
            this.bipartite_label.Text = "Bipartite Result: " + this.graph.IsBipartite().ToString();
            this.graphPanel.Invalidate();
        }
    }
}
