//#define OPEN_DEBUG

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Assets.Script
{
    public class UIEventListener : UnityEngine.EventSystems.EventTrigger
    {
        public delegate void GoDelegate(GameObject go, BaseEventData eventData);

        public List<GoDelegate> onClicks = new List<GoDelegate>();
        public List<GoDelegate> onDowns = new List<GoDelegate>();
        public List<GoDelegate> onUps = new List<GoDelegate>();
        public List<GoDelegate> onEnters = new List<GoDelegate>();
        public List<GoDelegate> onExits = new List<GoDelegate>();
        public List<GoDelegate> onSelects = new List<GoDelegate>();
        public List<GoDelegate> onBeginDrags = new List<GoDelegate>();
        public List<GoDelegate> onDrags = new List<GoDelegate>();
        public List<GoDelegate> onEndDrags = new List<GoDelegate>();




        /// <summary>
        /// Get the specified go.
        /// </summary>
        /// <param name="go">Go.</param>
        static public UIEventListener Get(GameObject go)
        {
            UIEventListener listener = go.GetComponent<UIEventListener>();
            if (listener == null)
            {
                listener = go.AddComponent<UIEventListener>();
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: Get : go.name = " + go.name + ", go.AddComponent<UIEventListener>()");
#endif
            }
            return listener;
        }



        #region unity functions
        /// <summary>
        /// Raises the pointer click event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (onClicks.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnPointerClick : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onClicks)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the pointer down event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (onDowns.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnPointerDown : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onDowns)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the pointer up event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (onUps.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnPointerUp : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onUps)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the pointer enter event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (onEnters.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnPointerEnter : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onEnters)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the pointer exit event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            if (onExits.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnPointerExit : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onExits)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the select event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            if (onSelects.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnSelect : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onSelects)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the drag event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            if (onBeginDrags.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnBeginDrag : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onBeginDrags)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the drag event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            if (onDrags.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnDrag : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onDrags)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// Raises the end drag event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            if (onEndDrags.Count > 0)
            {
#if OPEN_DEBUG
				Debug.Log("UIEventListener :: OnEndDrag : gameObject.name = " + gameObject.name);
#endif
                foreach (GoDelegate deleg in onEndDrags)
                    deleg(gameObject, eventData);
            }
        }

        /// <summary>
        /// OnDestroy
        /// </summary>
        void OnDestroy()
        {
            onClicks.Clear();
            onDowns.Clear();
            onUps.Clear();
            onEnters.Clear();
            onExits.Clear();
            onSelects.Clear();
            onBeginDrags.Clear();
            onDrags.Clear();
            onEndDrags.Clear();

#if OPEN_DEBUG
            Debug.Log("UIEventListener :: OnDestroy");
#endif
        }
        #endregion
    }
}


