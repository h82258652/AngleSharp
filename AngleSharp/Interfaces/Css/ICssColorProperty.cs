﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;

    /// <summary>
    /// Represents the CSS color property.
    /// </summary>
    public interface ICssColorProperty : ICssProperty
    {
        /// <summary>
        /// Gets the selected color for the foreground.
        /// </summary>
        Color Color { get; }
    }
}
