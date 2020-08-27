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
        public ClickableObjectsParent Parent {
            get
            {
                if (_parent == null)
                {
                    _parent = GetComponent<ClickableObjectsParent>();
                }

                return _parent;
            }
        }
        
        #endregion

        #region Monobehaviour methods

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Parent.onClick += ToggleObject;
        }

        private void OnDisable()
        {
            Parent.onClick -= ToggleObject;
        }
        
        #endregion

        public void ToggleObject()
        {
            if (_isOn) TurnObjectOff();
            else TurnObjectOn();
        }

        public override void TurnObjectOn()
        {
            if (_isOn) return;
            HandleAnimator(TurnOn);
            _isOn = true;
            NotifyOnStateChanged();
        }

        public override void TurnObjectOff()
        {
            if (!_isOn) return;
            HandleAnimator(TurnOff);
            _isOn = false;
            NotifyOnStateChanged();
        }
        
        #region Private methods
        private void HandleAnimator(int trigger)
        {
            if (_animator) {_animator.SetTrigger(trigger); }
        }
        
        #endregion
    }
}