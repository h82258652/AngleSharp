﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/CSS/animation-direction
    /// </summary>
    sealed class CSSAnimationDirectionProperty : CSSProperty, ICssAnimationDirectionProperty
    {
        #region Fields

        readonly List<AnimationDirection> _directions;

        #endregion

        #region ctor

        internal CSSAnimationDirectionProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.AnimationDirection, rule)
        {
            _directions = new List<AnimationDirection>();
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an iteration over all defined directions.
        /// </summary>
        public IEnumerable<AnimationDirection> Directions
        {
            get { return _directions; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _directions.Clear();
            _directions.Add(AnimationDirection.Normal);
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            var values = value.AsList<CSSPrimitiveValue>();

            if (values != null)
            {
                var fillModes = new List<AnimationDirection>();

                foreach (var item in values)
                {
                    var direction = item.ToDirection();

                    if (direction == null)
                        return false;

                    fillModes.Add(direction.Value);
                }

                _directions.Clear();
                _directions.AddRange(fillModes);
                return true;
            }
            
            return false;
        }

        #endregion
    }
}
