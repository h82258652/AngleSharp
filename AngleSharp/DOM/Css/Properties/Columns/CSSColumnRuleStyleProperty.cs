﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    /// </summary>
    sealed class CSSColumnRuleStyleProperty : CSSProperty, ICssColumnRuleStyleProperty
    {
        #region Fields

        LineStyle _style;

        #endregion

        #region ctor

        internal CSSColumnRuleStyleProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.ColumnRuleStyle, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected column-rule line style.
        /// </summary>
        public LineStyle Style
        {
            get { return _style; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _style = LineStyle.None;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var style = value.ToLineStyle();

            if (style.HasValue)
            {
                _style = style.Value;
                return true;
            }
            
            return false;
        }

        #endregion
    }
}
