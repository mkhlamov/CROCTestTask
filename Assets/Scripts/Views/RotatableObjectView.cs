using System;
using Models.ScriptableObjects;
using UnityEngine;
using Views.InteractableObjects;

namespace Views
{
    [RequireComponent(typeof(DragableObjectParent))]
    public class RotatableObjectView : ObjectView
    {
        [SerializeField] private RotatableObject rotatableObjectSO;
        [SerializeField] private float rotationSpeed = 1f;
        
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
        
        private float _currentRotation = 0f;

        private void OnEnable()
        {
            Parent.onDrag += Rotate;
        }
        
        private void OnDisable()
        {
            Parent.onDrag -= Rotate;
        }

        private void Rotate(Vector2 offset, Vector3 newMousePosition, DragableObject o)
        {
            _currentRotation -= Time.deltaTime * offset.x * 10000 * rotationSpeed;
            _currentRotation = Mathf.Clamp(_currentRotation, rotatableObjectSO.minAngle, rotatableObjectSO.maxAngle);
            
            SetRotation();
            
            if ((_isOn && _currentRotation == rotatableObjectSO.closedAngle) ||
                (!_isOn && _currentRotation == rotatableObjectSO.openedAngle))
            {
                _isOn = !_isOn;
                NotifyOnStateChanged();
            }
        }

        protected override void TurnObjectOn(bool notify = true)
        {
            _isOn = true;
            _currentRotation = rotatableObjectSO.openedAngle;
            SetRotation();
            base.TurnObjectOn(notify);
        }

        protected override void TurnObjectOff(bool notify = true)
        {
            _isOn = false;
            _currentRotation = rotatableObjectSO.closedAngle;
            SetRotation();
            base.TurnObjectOn(notify);
        }

        private void SetRotation()
        {
            var rot = transform.rotation.eulerAngles;
            switch (rotatableObjectSO.rotationAxis)
            {
                case RotationAxis.X:
                    rot.x = _currentRotation;
                    break;
                case RotationAxis.Y:
                    rot.y = _currentRotation;
                    break;
                case RotationAxis.Z:
                    rot.z = _currentRotation;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            transform.rotation = Quaternion.Euler(rot);
        }
    }
}