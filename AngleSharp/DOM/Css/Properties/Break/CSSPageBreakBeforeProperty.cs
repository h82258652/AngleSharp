﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/page-break-before
    /// </summary>
    sealed class CSSPageBreakBeforeProperty : CSSProperty, ICssPageBreakBeforeProperty
    {
        #region Fields

        BreakMode _mode;

        #endregion

        #region ctor

        internal CSSPageBreakBeforeProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.PageBreakBefore, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected break mode.
        /// </summary>
        public BreakMode State
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _mode = BreakMode.Auto;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var mode = value.ToPageBreakMode();

            if (mode.HasValue)
            {
                _mode = mode.Value;
                return true;
            }

            return false;
        }

        #endregion
    }
}
