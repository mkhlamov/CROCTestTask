using System;
using System.Collections;
using UnityEngine;
using Views.InteractableObjects;

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

        private Animator Animator
        {
            get
            {
                if (_animator == null)
                {
                    _animator = GetComponent<Animator>();
                }

                return _animator;
            }
        }
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

        private void OnEnable()
        {
            Parent.onClick += ToggleObject;
        }

        private void OnDisable()
        {
            Parent.onClick -= ToggleObject;
        }
        
        #endregion

        protected override void TurnObjectOn(bool notify=true)
        {
            if (_isOn) return;
            _isOn = true;
            StartCoroutine(HandleAnimator(TurnOn));
            base.TurnObjectOn(notify);
        }

        protected override void TurnObjectOff(bool notify=true)
        {
            if (!_isOn) return;
            _isOn = false;
            StartCoroutine(HandleAnimator(TurnOff));
            base.TurnObjectOff(notify);
        }
        
        #region Private methods
        private IEnumerator HandleAnimator(int trigger)
        {
            while (IsAnimatorPlaying())
            {
                yield return null;
            }
            Animator.SetTrigger(trigger);
        }

        private bool IsAnimatorPlaying()
        {
            return Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 ||
                   Animator.IsInTransition(0);
        }
        
        #endregion
    }
}