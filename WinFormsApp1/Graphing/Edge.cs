// <copyright file="Edge.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GraphTheorySketchPad.Graphing
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The public class to create an Edge.
    /// </summary>
    public class Edge : IGraphableItem
    {
        private Vertex vertex1; // The first vertex in the given edge.
        private Vertex vertex2; // The second vertex in the given edge.
        private Color color; // The edges color.
        private bool current; // Checks to see if the edge is currently selected.
        private bool isLoop; // Checks to see if the edge is in a loop or not.
        private int edgeWidth; // Determines the length (or width) or the edge.
        private int parallelEdge; // Determines whether or not the edge is parallel.

        /// <summary>
        /// Initializes a new instance of the <see cref="Edge"/> class.
        /// </summary>
        /// <param name="vertex1"> First vertex. </param>
        /// <param name="vertex2"> Second vertex. </param>
        /// <param name="edgeWidth"> Edge width. </param>
        public Edge(Vertex vertex1, Vertex vertex2, int edgeWidth, Color color)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.edgeWidth = edgeWidth;
            this.color = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edge"/> class.
        /// </summary>
        /// <param name="vertex1"> First vertex. </param>
        /// <param name="vertex2"> Second vertex. </param>
        /// <param name="edgeWidth"> Edge width. </param>
        /// <param name="parallelEdge"> The other parallel edge. </param>
        public Edge(Vertex vertex1, Vertex vertex2, int edgeWidth, int parallelEdge, Color color)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.edgeWidth = edgeWidth;
            this.parallelEdge = parallelEdge;
            this.color = color;
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is current or not.
        /// </summary>
        public bool IsCurrent
        {
            get
            {
                return this.current;
            }

            set
            {
                this.current = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether it is in a loop or not.
        /// </summary>
        public bool IsLoop
        {
            get
            {
                return this.isLoop;
            }
        }

        /// <summary>
        /// Gets the first vertex.
        /// </summary>
        public Vertex Vertex1
        {
            get
            {
                return this.vertex1;
            }
        }

        /// <summary>
        /// Gets the second vertex.
        /// </summary>
        public Vertex Vertex2
        {
            get
            {
            return this.vertex2;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }

            set
            {
                color = value;
            }
        }

        /// <summary>
        /// Draws the edge on the graphics object.
        /// </summary>
        /// <param name="g"> graphics object to draw on. </param>
        /// <param name="pen"> pen for drawing. </param>
        public void Draw(Graphics g, Pen pen)
        {
            using (var path = this.GetGraphicsPath())
            {
                g.DrawPath(pen, path);
            }
        }

        /// <summary>
        /// Gets the current graphics path of the object.
        /// </summary>
        /// <returns> The graphics path of the object. </returns>
        public GraphicsPath GetGraphicsPath()
        {
            GraphicsPath path = new GraphicsPath();
            int offsetRadius = this.vertex1.GetRadius;

            int x1 = this.vertex1.Coordinates.X + offsetRadius;
            int x2 = this.vertex2.Coordinates.X + offsetRadius;
            int y1 = this.vertex1.Coordinates.Y + offsetRadius;
            int y2 = this.vertex2.Coordinates.Y + offsetRadius;

            int parallelOffset = this.CalculateParallelOffset();

            // if the coordinants are horizantal, then:
            if (Math.Abs(x1) - Math.Abs(x2) > Math.Abs(y1) - Math.Abs(y2))
            {
                return this.BuildGraphicsPath(path, x1, y1, x2, y2, parallelOffset, 0);
            }

            // If the coordinants are vertical, then:
            else
            {
                return this.BuildGraphicsPath(path, x1, y1, x2, y2, 0, parallelOffset);
            }
        }

        /// <summary>
        /// Function implemented by the interface that returns whether the object was selected when the user clicked or not.
        /// </summary>
        /// <param name="clickPosition"> The position of the click. </param>
        /// <returns> If the object was selected or not. </returns>
        public bool IsObject(Point clickPosition)
        {
            Color colorWhite = Color.FromArgb(255, 255, 255, 255);
            var res = false;

            using (var path = this.GetGraphicsPath())
            using (var pen = new Pen(colorWhite, this.edgeWidth + 15))
            {
                res = path.IsOutlineVisible(clickPosition, pen);
            }

            return res;
        }

        /// <summary>
        /// Determines the offset amount for paralell edges.
        /// </summary>
        /// <returns> the offset. </returns>
        private int CalculateParallelOffset()
        {
            if (this.parallelEdge == 0)
            {
                return 0;
            }
            else if (this.parallelEdge % 2 == 0)
            {
                return -12 * this.parallelEdge;
            }
            else
            {
                return 12 * this.parallelEdge;
            }
        }

        /// <summary>
        /// Builds the path of the edge.
        /// </summary>
        /// <param name="path">base path to build on. </param>
        /// <param name="x1"> x1 coordinate. </param>
        /// <param name="y1"> x2 coordinate. </param>
        /// <param name="x2"> y1 coordinate. </param>
        /// <param name="y2"> y2 coordinate. </param>
        /// <param name="xOffset"> the amount x is offset by. </param>
        /// <param name="yOffset"> the amount y is offset by. </param>
        /// <returns> the path to the edge. </returns>
        private GraphicsPath BuildGraphicsPath(GraphicsPath path, int x1, int y1, int x2, int y2, int xOffset, int yOffset)
        {
            // loop
            if (this.vertex1 == this.vertex2)
            {
                int dim = 35 + (this.parallelEdge * 10);
                path.AddArc(new Rectangle(x1 - 16, y1, 30, dim), 0, 360);
                return path;
            }
            else
            {
                PointF[] points = new PointF[3];
                points[0] = new PointF(x1, y1);
                points[1] = new PointF(((x1 + x2) / 2) + xOffset, ((y1 + y2) / 2) + yOffset);
                points[2] = new PointF(x2, y2);

                path.AddCurve(points);
                return path;
            }
        }
    }
}
