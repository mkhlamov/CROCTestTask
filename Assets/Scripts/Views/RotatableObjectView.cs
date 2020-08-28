using System;
using Models.ScriptableObjects;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(DragableObjectParent))]
    public class RotatableObjectView : ObjectView
    {
        [SerializeField] private RotatableObject rotatableObjectSO;
        private DragableObjectParent _parent;
        public DragableObjectParent Parent {
            get
            {
                if (_parent == null)
                {
                    _parent = GetComponent<DragableObjectParent>();
                }

                return _parent;
            }
        }

        private void OnEnable()
        {
            Parent.onDrag += Rotate;
        }
        
        private void OnDisable()
        {
            Parent.onDrag -= Rotate;
        }

        private float _currentRotation = 0f;

        private void Rotate(Vector2 offset, Vector3 newMousePosition, DragableObject o)
        {
            _currentRotation -= Time.deltaTime * offset.x * 10000;
            _currentRotation = Mathf.Clamp(_currentRotation, rotatableObjectSO.minAngle, rotatableObjectSO.maxAngle);
            
            SetRotation();
            
            if ((_isOn && _currentRotation == rotatableObjectSO.closedAngle) ||
                (!_isOn && _currentRotation == rotatableObjectSO.openedAngle))
            {
                _isOn = !_isOn;
                NotifyOnStateChanged();
            }
        }

        public override void TurnObjectOn()
        {
            _currentRotation = rotatableObjectSO.openedAngle;
            SetRotation();
        }

        public override void TurnObjectOff()
        {
            _currentRotation = rotatableObjectSO.closedAngle;
            SetRotation();
        }

        private void SetRotation()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, _currentRotation, transform.rotation.z);
        }
    }
}