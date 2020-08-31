using System;
using UnityEngine;

namespace Views
{
    /// <summary>
    /// Base class for object views
    /// </summary>
    public abstract class ObjectView : MonoBehaviour
    {
        public Action<ObjectView, bool> OnDeviceStateChanged;
        
        protected bool _isOn = true;
        public bool IsOn
        {
            get => _isOn;
            set => _isOn = value;
        }

        /// <summary>
        /// Turns Object View on
        /// </summary>
        protected virtual void TurnObjectOn(bool notify = true)
        {
            if (notify) NotifyOnStateChanged();
        }

        /// <summary>
        /// Turn Object View off
        /// </summary>
        protected virtual void TurnObjectOff(bool notify = true)
        {
            if (notify) NotifyOnStateChanged();
        }

        public void TurnObjectToState(bool e)
        {
            if (e) TurnObjectOn();
            else TurnObjectOff();
        }

        public void ToggleObject()
        {
            ToggleObjectWithNotification(true);
        }

        public void ToggleObjectWithNotification(bool notify = true)
        {
            if (_isOn) TurnObjectOff(notify);
            else TurnObjectOn(notify);
        }

        protected void NotifyOnStateChanged()
        {
            OnDeviceStateChanged?.Invoke(this, _isOn);
        }
    }
}