﻿namespace AngleSharp.DOM.Html
{
    using AngleSharp.Html;
    using System;
    
    /// <summary>
    /// Represents the HTML html element.
    /// </summary>
    sealed class HTMLHtmlElement : HTMLElement, IHtmlHtmlElement
    {
        #region ctor

        /// <summary>
        /// Creates a new HTML html tag.
        /// </summary>
        internal HTMLHtmlElement()
            : base(Tags.Html, NodeFlags.Special | NodeFlags.ImplicitelyClosed | NodeFlags.Scoped | NodeFlags.HtmlTableScoped | NodeFlags.HtmlTableSectionScoped)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the manifest attribute.
        /// </summary>
        public String Manifest 
        {
            get { return GetAttribute(AttributeNames.Manifest); }
            set { SetAttribute(AttributeNames.Manifest, value); }
        }

        #endregion
    }
}
