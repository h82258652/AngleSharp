﻿namespace AngleSharp.DOM.Html
{
    using AngleSharp.Attributes;
    using AngleSharp.Html;

    /// <summary>
    /// Represents the HTML dir element.
    /// This element is obsolete since HTML 4.01.
    /// </summary>
    [DomHistorical]
    sealed class HTMLDirectoryElement : HTMLElement
    {
        #region ctor

        internal HTMLDirectoryElement()
            : base (Tags.Dir, NodeFlags.Special)
        {
        }

        #endregion
    }
}
