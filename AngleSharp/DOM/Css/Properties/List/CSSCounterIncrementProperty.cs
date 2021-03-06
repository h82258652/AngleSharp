﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/counter-increment
    /// </summary>
    sealed class CSSCounterIncrementProperty : CSSProperty, ICssCounterIncrementProperty
    {
        #region Fields

        readonly Dictionary<String, Int32> _increments;

        #endregion

        #region ctor

        internal CSSCounterIncrementProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.CounterIncrement, rule)
        {
            _increments = new Dictionary<String, Int32>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the increment of the specified counter.
        /// </summary>
        /// <param name="counter"></param>
        /// <returns></returns>
        public Int32 this[String counter]
        {
            get { return _increments[counter]; }
        }

        /// <summary>
        /// Gets an enumeration over all counters.
        /// </summary>
        public IEnumerable<String> Counters
        {
            get { return _increments.Keys; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _increments.Clear();
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            if (value is CSSValueList)
                return CheckList((CSSValueList)value);

            var primitive = value as CSSPrimitiveValue;

            if (primitive != null && primitive.Unit == UnitType.Ident)
                return CheckIdentifier(primitive);

            return false;
        }

        Boolean CheckIdentifier(CSSPrimitiveValue ident)
        {
            _increments.Clear();

            if (!ident.Is(Keywords.None))
                _increments.Add(ident.GetString(), 1);

            return true;
        }

        Boolean CheckList(CSSValueList list)
        {
            var entries = new List<KeyValuePair<String, Int32>>();

            for (int i = 0; i < list.Length; i++)
            {
                var primitive = list[i] as CSSPrimitiveValue;

                if (primitive == null || primitive.Unit != UnitType.Ident)
                    return false;

                var ident = primitive.GetString();
                var num = 1;

                if (i + 1 < list.Length)
                {
                    var number = list[i + 1].ToInteger();

                    if (number.HasValue)
                    {
                        i++;
                        num = number.Value;
                    }
                }

                entries.Add(new KeyValuePair<String, Int32>(ident, num));
            }

            _increments.Clear();

            foreach (var entry in entries)
                _increments[entry.Key] = entry.Value;

            return true;
        }

        #endregion
    }
}
