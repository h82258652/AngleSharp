﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/unicode-bidi
    /// </summary>
    sealed class CSSUnicodeBidiProperty : CSSProperty, ICssUnicodeBidiProperty
    {
        #region Fields

        static readonly Dictionary<String, UnicodeMode> modes = new Dictionary<String, UnicodeMode>(StringComparer.OrdinalIgnoreCase);
        UnicodeMode _mode;

        #endregion

        #region ctor

        static CSSUnicodeBidiProperty()
        {
            modes.Add(Keywords.Normal, UnicodeMode.Normal);
            modes.Add(Keywords.Embed, UnicodeMode.Embed);
            modes.Add(Keywords.Isolate, UnicodeMode.Isolate);
            modes.Add(Keywords.IsolateOverride, UnicodeMode.IsolateOverride);
            modes.Add(Keywords.BidiOverride, UnicodeMode.BidiOverride);
            modes.Add(Keywords.Plaintext, UnicodeMode.Plaintext);
        }

        internal CSSUnicodeBidiProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.UnicodeBidi, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected unicode mode.
        /// </summary>
        public UnicodeMode State
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _mode = UnicodeMode.Normal;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            UnicodeMode mode;

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
