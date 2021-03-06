﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom
    /// </summary>
    sealed class CSSBorderBottomProperty : CSSShorthandProperty, ICssBorderProperty
    {
        #region Fields

        readonly CSSBorderBottomColorProperty _color;
        readonly CSSBorderBottomStyleProperty _style;
        readonly CSSBorderBottomWidthProperty _width;

        #endregion

        #region ctor

        internal CSSBorderBottomProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderBottom, rule, PropertyFlags.Animatable)
        {
            _color = Get<CSSBorderBottomColorProperty>();
            _style = Get<CSSBorderBottomStyleProperty>();
            _width = Get<CSSBorderBottomWidthProperty>();
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

            return _width.TrySetValue(width) && _color.TrySetValue(color) && _style.TrySetValue(style);
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
