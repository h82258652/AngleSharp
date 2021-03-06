﻿namespace AngleSharp.Parser.Css
{
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Represents a CSS string token.
    /// </summary>
    sealed class CssStringToken : CssToken
    {
        #region Fields

        readonly Boolean _bad;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new CSS string token.
        /// </summary>
        /// <param name="type">The exact type.</param>
        /// <param name="data">The string data.</param>
        /// <param name="bad">If the string was bad (optional).</param>
        CssStringToken(CssTokenType type, String data, Boolean bad)
            : base(type, data)
        {
            _bad = bad;
        }

        /// <summary>
        /// Creates a new CSS string token (plain string).
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <param name="bad">If the string was bad (optional).</param>
        /// <returns>The created string token.</returns>
        public static CssStringToken Plain(String data, Boolean bad = false)
        {
            return new CssStringToken(CssTokenType.String, data, bad);
        }

        /// <summary>
        /// Creates a new CSS string token (URL string).
        /// </summary>
        /// <param name="token">The token type (url, urlprefix, domain).</param>
        /// <param name="data">The URL string data.</param>
        /// <param name="bad">If the URL was bad (optional).</param>
        /// <returns>The created URL string token.</returns>
        public static CssStringToken Url(CssTokenType token, String data, Boolean bad = false)
        {
            return new CssStringToken(token, data, bad);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets if the data is bad.
        /// </summary>
        public Boolean IsBad
        {
            get { return _bad; }
        }

        #endregion

        #region String representation

        /// <summary>
        /// Gets a string which represents the original value.
        /// </summary>
        /// <returns>The original value.</returns>
        public override String ToValue()
        {
            if (Type == CssTokenType.Url)
                return Data.CssUrl();

            return Data.CssString();
        }

        #endregion
    }
}
