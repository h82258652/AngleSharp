﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    /// or even better:
    /// http://dev.w3.org/csswg/css-backgrounds/#border-image-slice
    /// </summary>
    sealed class CSSBorderImageSliceProperty : CSSProperty, ICssBorderImageSliceProperty
    {
        #region Fields

        IDistance _top;
        IDistance _right;
        IDistance _bottom;
        IDistance _left;
        Boolean _fill;

        #endregion

        #region ctor

        internal CSSBorderImageSliceProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.BorderImageSlice, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the position of the top slicing line.
        /// </summary>
        public IDistance SliceTop
        {
            get { return _top; }
        }

        /// <summary>
        /// Gets the position of the right slicing line.
        /// </summary>
        public IDistance SliceRight
        {
            get { return _right; }
        }

        /// <summary>
        /// Gets the position of the bottom slicing line.
        /// </summary>
        public IDistance SliceBottom
        {
            get { return _bottom; }
        }

        /// <summary>
        /// Gets the position of the left slicing line.
        /// </summary>
        public IDistance SliceLeft
        {
            get { return _left; }
        }

        /// <summary>
        /// Gets if the center patch should be filled.
        /// </summary>
        public Boolean IsFilled
        {
            get { return _fill; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _top = Percent.Hundred;
            _right = Percent.Hundred;
            _bottom = Percent.Hundred;
            _left = Percent.Hundred;
            _fill = false;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var mode = value.ToBorderSlice();

            if (mode != null)
                _top = _left = _bottom = _right = mode;
            else if (value is CSSValueList)
                return Evaluate((CSSValueList)value);
            else
                return false;

            return true;
        }

        Boolean Evaluate(CSSValueList values)
        {
            if (values.Length > 5)
                return false;

            var fill = false;
            var modes = new List<IDistance>(values.Length);

            foreach (var value in values)
            {
                if (!fill && value.Is(Keywords.Fill))
                    fill = true;
                else if (value.ToBorderSlice() == null)
                    return false;
                else
                    modes.Add(value.ToBorderSlice());
            }

            if (modes.Count == 5 || modes.Count == 0)
                return false;

            _fill = fill;
            _bottom = _left = _right = _top = modes[0];

            if (modes.Count > 1)
            {
                _left = _right = modes[1];

                if (modes.Count > 2)
                {
                    _bottom = modes[2];

                    if (modes.Count > 3)
                        _left = modes[3];
                }
            }

            return true;
        }

        #endregion
    }
}
