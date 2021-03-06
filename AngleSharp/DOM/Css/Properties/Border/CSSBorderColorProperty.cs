﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    /// </summary>
    sealed class CSSBorderColorProperty : CSSShorthandProperty, ICssBorderColorsProperty
    {
        #region Fields

        readonly CSSBorderTopColorProperty _top;
        readonly CSSBorderRightColorProperty _right;
        readonly CSSBorderBottomColorProperty _bottom;
        readonly CSSBorderLeftColorProperty _left;

        #endregion

        #region ctor

        internal CSSBorderColorProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderColor, rule, PropertyFlags.Hashless | PropertyFlags.Animatable)
        {
            _top = Get<CSSBorderTopColorProperty>();
            _right = Get<CSSBorderRightColorProperty>();
            _bottom = Get<CSSBorderBottomColorProperty>();
            _left = Get<CSSBorderLeftColorProperty>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value for the color of the top border.
        /// </summary>
        public Color Top
        {
            get { return _top.Color; }
        }

        /// <summary>
        /// Gets the value for the color of the right border.
        /// </summary>
        public Color Right
        {
            get { return _right.Color; }
        }

        /// <summary>
        /// Gets the value for the color of the bottom border.
        /// </summary>
        public Color Bottom
        {
            get { return _bottom.Color; }
        }

        /// <summary>
        /// Gets the value for the color of the left border.
        /// </summary>
        public Color Left
        {
            get { return _left.Color; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            return ValidatePeriodic(value, _top, _right, _bottom, _left);
        }

        internal override String SerializeValue(IEnumerable<CSSProperty> properties)
        {
            if (!IsComplete(properties))
                return String.Empty;

            return SerializePeriodic(_top, _right, _bottom, _left);
        }

        #endregion
    }
}
