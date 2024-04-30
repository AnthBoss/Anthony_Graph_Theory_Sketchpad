// <copyright file="IGraphableItem.cs" company="PlaceholderCompany">
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
    /// The interface for objects that will gain the interface GraphableObject.
    /// </summary>
    public interface IGraphableItem
    {
        /// <summary>
        /// This will check to see if an object or item is graphable given the clicked location.
        /// </summary>
        /// <param name="click"> the position of the mouse when it clicked. </param>
        /// <returns> Whether the object was clicked or not clicked. </returns>
        bool IsObject(Point click);

        /// <summary>
        /// The function that will physically draw the objects onto the screen.
        /// </summary>
        /// <param name="g"> The graphics selected. </param>
        /// <param name="pen"> The pen selected. </param>
        void Draw(Graphics g, Pen pen);
    }
}
