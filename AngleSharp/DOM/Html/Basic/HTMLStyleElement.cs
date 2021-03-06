﻿namespace AngleSharp.DOM.Html
{
    using AngleSharp.Extensions;
    using AngleSharp.Html;
    using AngleSharp.Infrastructure;
    using System;

    /// <summary>
    /// Represents the HTML style element.
    /// </summary>
    sealed class HTMLStyleElement : HTMLElement, IHtmlStyleElement
    {
        #region Fields

        IStyleSheet _sheet;

        #endregion

        #region ctor

        /// <summary>
        /// Creates an HTML style element.
        /// </summary>
        internal HTMLStyleElement()
            : base(Tags.Style, NodeFlags.Special | NodeFlags.LiteralText)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if the style is scoped.
        /// </summary>
        public Boolean IsScoped
        {
            get { return GetAttribute(AttributeNames.Scoped) != null; }
            set { SetAttribute(AttributeNames.Scoped, value ? String.Empty : null); }
        }

        /// <summary>
        /// Gets the associated style sheet.
        /// </summary>
        public IStyleSheet Sheet
        {
            get { return _sheet; }
        }

        /// <summary>
        /// Gets or sets if the style is enabled or disabled.
        /// </summary>
        public Boolean IsDisabled
        {
            get { return GetAttribute(AttributeNames.Disabled).ToBoolean(); }
            set 
            {
                SetAttribute(AttributeNames.Disabled, value ? String.Empty : null);

                if (_sheet != null) 
                    _sheet.IsDisabled = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use with one or more target media.
        /// </summary>
        public String Media
        {
            get { return GetAttribute(AttributeNames.Media); }
            set { SetAttribute(AttributeNames.Media, value); }
        }

        /// <summary>
        /// Gets or sets the content type of the style sheet language.
        /// </summary>
        public String Type
        {
            get { return GetAttribute(AttributeNames.Type); }
            set { SetAttribute(AttributeNames.Type, value); }
        }

        #endregion

        #region Internal methods

        internal override void Close()
        {
            base.Close();

            RegisterAttributeHandler(AttributeNames.Media, value =>
            {
                if (_sheet != null)
                    _sheet.Media.MediaText = Media;
            });

            UpdateSheet();
        }

        internal override void NodeIsInserted(Node newNode)
        {
            base.NodeIsInserted(newNode);
            UpdateSheet();
        }

        internal override void NodeIsRemoved(Node removedNode, Node oldPreviousSibling)
        {
            base.NodeIsRemoved(removedNode, oldPreviousSibling);
            UpdateSheet();
        }

        #endregion

        #region Helpers

        void UpdateSheet()
        {
            if (Owner.Options.IsStyling)
            {
                var options = new StyleOptions 
                { 
                    Element = this, 
                    Document = Owner, 
                    Context = Owner.DefaultView, 
                    IsDisabled = IsDisabled, 
                    Title = Title 
                };
                _sheet = Owner.Options.ParseStyling(TextContent, options, Type);
            }
        }

        #endregion
    }
}
