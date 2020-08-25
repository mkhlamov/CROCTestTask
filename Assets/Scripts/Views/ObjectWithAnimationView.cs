using System;
using UnityEngine;

namespace Views
{
    /// <summary>
    /// Objects with on/off state with animation 
    /// </summary>
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(ClickableObjectsParent))]
    public class ObjectWithAnimationView : ObjectView
    {
        #region Private variables
        
        private Animator _animator;
        private static readonly int TurnOn = Animator.StringToHash("TurnOn");
        private static readonly int TurnOff = Animator.StringToHash("TurnOff");

        private ClickableObjectsParent _parent;
        public ClickableObjectsParent Parent => _parent;
        
        #endregion
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _parent = GetComponent<ClickableObjectsParent>();
        }

        public void ToggleObject()
        {
            if (_isOn) TurnObjectOff();
            else TurnObjectOn();
        }

        #region Private methods
        
        private void TurnObjectOn()
        {
            if (_isOn) return;
            HandleAnimator(TurnOn);
            _isOn = true;
        }
        
        private void TurnObjectOff()
        {
            if (!_isOn) return;
            HandleAnimator(TurnOff);
            _isOn = false;
        }

        private void HandleAnimator(int trigger)
        {
            if (_animator) {_animator.SetTrigger(trigger); }
        }
        
        #endregion
    }
}