﻿namespace AngleSharp.Css
{
    using System;

    /// <summary>
    /// More information can be found at the W3C:
    /// http://dev.w3.org/csswg/css-images-3/#color-stop-syntax
    /// </summary>
    public struct GradientStop : ICssObject
    {
        #region Fields

        readonly Color _color;
        readonly IDistance _location;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new gradient stop.
        /// </summary>
        /// <param name="color">The color of the stop.</param>
        /// <param name="location">The location of the stop.</param>
        public GradientStop(Color color, IDistance location)
        {
            _color = color;
            _location = location;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the color of the gradient stop.
        /// </summary>
        public Color Color
        {
            get { return _color; }
        }

        /// <summary>
        /// Gets the location of the gradient stop.
        /// </summary>
        public IDistance Location
        {
            get { return _location; }
        }

        #endregion

        #region String Representation

        /// <summary>
        /// Returns the CSS standard represenation, which is just color and location.
        /// </summary>
        /// <returns>A string that contains the color and location of the stop.</returns>
        public String ToCss()
        {
            return String.Concat(_color.ToCss(), " ", _location.ToCss());
        }

        #endregion
    }
}
