﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-left
    /// </summary>
    sealed class CSSBorderLeftProperty : CSSShorthandProperty, ICssBorderProperty
    {
        #region Fields

        readonly CSSBorderLeftColorProperty _color;
        readonly CSSBorderLeftStyleProperty _style;
        readonly CSSBorderLeftWidthProperty _width;

        #endregion

        #region ctor

        internal CSSBorderLeftProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderLeft, rule, PropertyFlags.Animatable)
        {
            _color = Get<CSSBorderLeftColorProperty>();
            _style = Get<CSSBorderLeftStyleProperty>();
            _width = Get<CSSBorderLeftWidthProperty>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the width of the given border property.
        /// </summary>
        public Length Width
        {
            get { return _width.Width; }
        }

        /// <summary>
        /// Gets the color of the given border property.
        /// </summary>
        public Color Color
        {
            get { return _color.Color; }
        }

        /// <summary>
        /// Gets the style of the given border property.
        /// </summary>
        public LineStyle Style
        {
            get { return _style.Style; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var list = value as CSSValueList ?? new CSSValueList(value);
            CSSValue width = null, color = null, style = null;

            if (list.Length > 3)
                return false;

            for (int i = 0; i < list.Length; i++)
            {
                if (!_width.CanStore(list[i], ref width) && !_style.CanStore(list[i], ref style) && !_color.CanStore(list[i], ref color))
                    return false;
            }

            return _width.TrySetValue(width) && _style.TrySetValue(style) && _color.TrySetValue(color);
        }

        internal override String SerializeValue(IEnumerable<CSSProperty> properties)
        {
            if (!IsComplete(properties))
                return String.Empty;

            return String.Format("{0} {1} {2}", _width.SerializeValue(), _style.SerializeValue(), _color.SerializeValue());
        }

        #endregion
    }
}
