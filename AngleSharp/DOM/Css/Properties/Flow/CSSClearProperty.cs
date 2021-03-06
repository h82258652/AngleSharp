﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/clear
    /// </summary>
    sealed class CSSClearProperty : CSSProperty, ICssClearProperty
    {
        #region Fields

        static readonly Dictionary<String, ClearMode> modes = new Dictionary<String, ClearMode>(StringComparer.OrdinalIgnoreCase);
        ClearMode _mode;

        #endregion

        #region ctor

        static CSSClearProperty()
        {
            modes.Add(Keywords.None, ClearMode.None);
            modes.Add(Keywords.Left, ClearMode.Left);
            modes.Add(Keywords.Right, ClearMode.Right);
            modes.Add(Keywords.Both, ClearMode.Both);
        }

        internal CSSClearProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.Clear, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value of the clear mode.
        /// </summary>
        public ClearMode State
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _mode = ClearMode.None;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            ClearMode mode;

            if (modes.TryGetValue(value, out mode))
            {
                _mode = mode;
                return true;
            }
            
            return false;
        }

        #endregion
    }
}
