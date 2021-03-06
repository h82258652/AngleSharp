﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    /// </summary>
    sealed class CSSTextIndentProperty : CSSProperty, ICssTextIndentProperty
    {
        #region Fields

        IDistance _indent;

        #endregion

        #region ctor

        internal CSSTextIndentProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.TextIndent, rule, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the indentation, which is either a percentage of the containing block width
        /// or specified as fixed length. Negative values are allowed.
        /// </summary>
        public IDistance Indent
        {
            get { return _indent; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _indent = Percent.Zero;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var indent = value.ToDistance();

            if (indent != null)
            {
                _indent = indent;
                return true;
            }
            
            return false;
        }

        #endregion
    }
}
