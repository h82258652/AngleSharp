﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en/docs/Web/CSS/@font-face
    /// </summary>
    sealed class CSSUnicodeRangeProperty : CSSProperty
    {
        public CSSUnicodeRangeProperty(CSSStyleDeclaration style)
            : base(PropertyNames.UnicodeRange, style)
        {
        }

        internal override void Reset()
        {
        }

        protected override Boolean IsValid(CSSValue value)
        {
            return true;
        }
    }
}
