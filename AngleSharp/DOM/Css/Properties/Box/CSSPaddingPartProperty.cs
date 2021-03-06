﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Basis for all elementary padding properties.
    /// </summary>
    abstract class CSSPaddingPartProperty : CSSProperty
    {
        #region Fields

        IDistance _padding;

        #endregion

        #region ctor

        internal CSSPaddingPartProperty(String name, CSSStyleDeclaration rule)
            : base(name, rule, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the padding relative to the width of the containing block or
        /// a fixed width.
        /// </summary>
        internal IDistance Padding
        {
            get { return _padding; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _padding = Percent.Zero;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var distance = value.ToDistance();

            if (distance != null)
            {
                _padding = distance;
                return true;
            }
            
            return false;
        }

        #endregion
    }
}
