﻿namespace AngleSharp.DOM.Html
{
    using AngleSharp.Extensions;
    using AngleSharp.Html;
    using System;

    /// <summary>
    /// Represents the HTML frame element.
    /// </summary>
    sealed class HTMLFrameElement : HTMLFrameElementBase
    {
        #region ctor

        public HTMLFrameElement()
            : base(Tags.Frame, NodeFlags.SelfClosing)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if the frame cannot be resized.
        /// </summary>
        public Boolean NoResize
        {
            get { return GetAttribute(AttributeNames.NoResize).ToBoolean(false); }
            set { SetAttribute(AttributeNames.NoResize, value.ToString()); }
        }

        #endregion
    }
}
