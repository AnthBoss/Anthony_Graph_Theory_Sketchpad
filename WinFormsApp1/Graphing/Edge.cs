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
        public Edge(Vertex vertex1, Vertex vertex2, int edgeWidth)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.edgeWidth = edgeWidth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edge"/> class.
        /// </summary>
        /// <param name="vertex1"> First vertex. </param>
        /// <param name="vertex2"> Second vertex. </param>
        /// <param name="edgeWidth"> Edge width. </param>
        /// <param name="parallelEdge"> The other parallel edge. </param>
        public Edge(Vertex vertex1, Vertex vertex2, int edgeWidth, int parallelEdge)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.edgeWidth = edgeWidth;
            this.parallelEdge = parallelEdge;
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
    }
}
