﻿namespace AngleSharp.Parser.Html
{
    using System;

    /// <summary>
    /// The token that is used for comments.
    /// </summary>
    sealed class HtmlCommentToken : HtmlToken
    {
        #region ctor

        /// <summary>
        /// Creates a new comment token with the supplied data.
        /// </summary>
        /// <param name="data">The data to set.</param>
        public HtmlCommentToken(String data)
        {
            _type = HtmlTokenType.Comment;
            _name = data;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the position of the token.
        /// </summary>
        public TextPosition Start
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the position of the token.
        /// </summary>
        public TextPosition End
        {
            get;
            set;
        }

        #endregion
    }
}
