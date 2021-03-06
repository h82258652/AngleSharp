﻿namespace AngleSharp.DOM.Events
{
    using AngleSharp.Attributes;
    using System;

    /// <summary>
    /// Represents the arguments for a focus event.
    /// </summary>
    [DomName("FocusEvent")]
    public class FocusEvent : UiEvent
    {
        #region Properties

        /// <summary>
        /// Gets the target of the event.
        /// </summary>
        [DomName("relatedTarget")]
        public IEventTarget Target
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the focus event.
        /// </summary>
        /// <param name="type">The type of event.</param>
        /// <param name="bubbles">Determines if the event bubbles.</param>
        /// <param name="cancelable">Determines if the event is cancelable.</param>
        /// <param name="view">Sets the associated view for the UI event.</param>
        /// <param name="detail">Sets the detail id for the UIevent.</param>
        /// <param name="target">The target that is being focused.</param>
        [DomName("initFocusEvent")]
        public void Init(String type, Boolean bubbles, Boolean cancelable, IWindow view, Int32 detail, IEventTarget target)
        {
            Init(type, bubbles, cancelable, view, detail);
            Target = target;
        }

        #endregion
    }
}
