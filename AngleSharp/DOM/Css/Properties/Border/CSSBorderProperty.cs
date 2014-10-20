﻿namespace AngleSharp.DOM.Css
{
    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border
    /// </summary>
    sealed class CSSBorderProperty : CSSBorderPartProperty, ICssBorderProperty
    {
        #region ctor

        internal CSSBorderProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.Border, rule)
        {
        }

        #endregion
    }
}
