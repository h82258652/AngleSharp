﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;

    /// <summary>
    /// Represents the CSS min-height property.
    /// </summary>
    public interface ICssMinHeightProperty : ICssProperty
    {
        /// <summary>
        /// Gets the minimum height of the element.
        /// </summary>
        IDistance Limit { get; }
    }
}
