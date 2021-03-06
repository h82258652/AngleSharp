﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Basis for all elementary border-radius properties.
    /// </summary>
    abstract class CSSBorderRadiusPartProperty : CSSProperty
    {
        #region Fields

        IDistance _h;
        IDistance _v;

        #endregion

        #region ctor

        internal CSSBorderRadiusPartProperty(String name, CSSStyleDeclaration rule)
            : base(name, rule, PropertyFlags.Animatable)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the horizontal radius of the ellipse.
        /// </summary>
        public IDistance HorizontalRadius
        {
            get { return _h; }
        }

        /// <summary>
        /// Gets if the horizontal radius is the same as the vertical one.
        /// </summary>
        public Boolean IsCircle
        {
            get { return _h.Equals(_v); }
        }

        /// <summary>
        /// Gets the vertical radius of the ellipse.
        /// </summary>
        public IDistance VerticalRadius
        {
            get { return _v; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _h = Percent.Zero;
            _v = Percent.Zero;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var list = value as CSSValueList;
            var v1 = value;
            var v2 = value;

            if (list != null)
            {
                if (list.Length != 2)
                    return false;

                v1 = list[0];
                v2 = list[1];
            }

            var c1 = v1.ToDistance();
            var c2 = v2.ToDistance();

            if (c1 == null || c2 == null)
                return false;

            _h = c1;
            _v = c2;
            return true;
        }

        #endregion
    }
}
