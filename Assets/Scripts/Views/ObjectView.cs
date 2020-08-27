using System;
using UnityEngine;

namespace Views
{
    /// <summary>
    /// Base class for object views
    /// </summary>
    public abstract class ObjectView : MonoBehaviour
    {
        public Action<GameObject, bool> OnDeviceStateChanged;
        
        protected bool _isOn = true;
        public bool IsOn => _isOn;

        /// <summary>
        /// Turns Object View on
        /// </summary>
        public abstract void TurnObjectOn();

        /// <summary>
        /// Turn Object View off
        /// </summary>
        public abstract void TurnObjectOff();

        public void TurnObjectToState(bool e)
        {
            if (e) TurnObjectOn();
            else TurnObjectOff();
        }

        public void NotifyOnStateChanged()
        {
            OnDeviceStateChanged?.Invoke(gameObject, _isOn);
        }
    }
}