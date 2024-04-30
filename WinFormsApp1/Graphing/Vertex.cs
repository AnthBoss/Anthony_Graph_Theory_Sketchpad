﻿// <copyright file="Vertex.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GraphTheorySketchPad.Graphing
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The public class that initializes a vertex.
    /// </summary>
    public class Vertex : IGraphableItem
    {
        /// <summary>
        /// This is to identify the given vertex.
        /// </summary>
        private string id;

        /// <summary>
        /// Bool to check if this is the currently selected vertex.
        /// </summary>
        private bool current;

        /// <summary>
        /// A coordinant value, containing where the vertex is located.
        /// </summary>
        private Point point;

        /// <summary>
        /// Size of the Vertex.
        /// </summary>
        private int radius;

        private int parallelEdges;
        private List<Edge> connectedEdges;
        private List<Vertex> neighbors;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// </summary>
        /// <param name="id"> The id of the vertex. </param>
        /// <param name="point"> The coordinants of the vertex. </param>
        /// <param name="radius"> The size or radius of the vertex. </param>
        public Vertex(string id, Point point, int radius)
        {
            this.id = id;
            this.current = false;
            this.radius = radius;
            this.parallelEdges = 0;

            // This is for the point adjusting to the screen.
            // This solution was found on a github forum.
            Point p = point;
            p.Offset(-radius, -radius);
            this.point = p;

            this.connectedEdges = new List<Edge>();
            this.neighbors = new List<Vertex>();
        }

        /// <summary>
        /// Gets a list of the neighbors who are adjacent to this vertex.
        /// </summary>
        public List<Vertex> GetNeighbors
        {
            get
            {
                return this.neighbors;
            }
        }

        /// <summary>
        /// Gets a list of the connected edges to this vertex.
        /// </summary>
        public List<Edge> GetConnectedEdges
        {
            get
            {
                return this.connectedEdges;
            }
        }

        /// <summary>
        /// Gets the radius or size of the vertex.
        /// </summary>
        public int GetRadius
        {
            get
            {
                return this.radius;
            }
        }

        /// <summary>
        /// Gets the int value of the parallel edges connected to this vertex.
        /// </summary>
        public int GetParallelEdges
        {
            get
            {
                return this.parallelEdges;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the string.
        /// </summary>
        public string ID
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is currently selected or not selected, in this case the vertex.
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
        /// Gets or sets the point value which is stored for the location of the coordinants of the vertex.
        /// </summary>
        public Point Coordinates
        {
            get
            {
                return this.point;
            }

            set
            {
                this.point = value;
            }
        }
    }
}