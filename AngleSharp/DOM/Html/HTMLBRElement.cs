﻿namespace AngleSharp.DOM.Html
{
    using AngleSharp.Html;

    /// <summary>
    /// Represents the HTML br element.
    /// </summary>
    sealed class HTMLBRElement : HTMLElement, IHtmlBreakRowElement
    {
        #region ctor

        /// <summary>
        /// Creates a new HTML br element
        /// </summary>
        internal HTMLBRElement()
            : base(Tags.Br, NodeFlags.Special | NodeFlags.SelfClosing)
        {
        }

        #endregion
    }
}
