﻿namespace AngleSharp.DOM
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The DOMStringMap interface represents a set of name-value pairs.
    /// </summary>
    [DomName("DOMStringMap")]
    public interface IStringMap : IEnumerable<KeyValuePair<String, String>>
    {
        /// <summary>
        /// Gets or sets an item in the dictionary.
        /// </summary>
        /// <param name="name">The name of the item to get or set.</param>
        /// <returns>The item with the associated name.</returns>
        [DomName("item")]
        String this [String name] { get; set; }
    }
}