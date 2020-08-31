using System;
using System.Collections.Generic;
using System.Linq;
using Models.ScriptableObjects;
using UnityEngine;
using Views.InteractableObjects;

namespace Views
{
    [RequireComponent(typeof(DragableObjectParent))]
    public class MovableObjectView : ObjectView
    {
        public MovableObject movableObjectSO;
        public Transform openedTransform;
        public Transform closedTransform;

        [SerializeField] private bool allowMovementAlongAxisX = true;
        [SerializeField] private bool allowMovementAlongAxisY = true;
        [SerializeField] private List<Collider> checkOverlapWith;
        
        private DragableObjectParent _parent;

        public DragableObjectParent Parent
        {
            get
            {
                if (_parent == null)
                {
                    _parent = GetComponent<DragableObjectParent>();
                }

                return _parent;
            }
        }

        #region Private variables
        
        private Camera _camera => Camera.main;
        private Vector3 _offsetToObj;
        private Bounds _bounds;
        private Vector3 _offsetToBoundsCenter;
        private Collider[] _overlapColliders = new Collider[32];
        private List<Collider> _childrenColliders;
        #endregion

        private void OnEnable()
        {
            Parent.onDrag += Move;
            Parent.onMouseDown += OnStartMove;
            _isOn = GetDistanceToStart() < movableObjectSO.distanceToOpened;
            _bounds = GetBoundBox();
            _offsetToBoundsCenter = _bounds.center - transform.position;
        }
        
        private void OnDisable()
        {
            Parent.onDrag -= Move;
            Parent.onMouseDown -= OnStartMove;
        }

        /// <summary>
        /// Moves parent object when dragableObject is dragged
        /// </summary>
        /// <param name="offset">Mouse offset</param>
        /// <param name="newMousePosition"></param>
        /// <param name="dragableObject">Object being dragged by user</param>
        public void Move(Vector2 offset, Vector3 newMousePosition, DragableObject dragableObject)
        {
            var pos = GetNewWorldPosition(newMousePosition);

            if (IsOverlapping(pos)) return;

            transform.position = pos;

            if (((transform.position - closedTransform.position).magnitude >= movableObjectSO.distanceToOpened ||
                (transform.position - closedTransform.position).magnitude > movableObjectSO.precision)
                && !_isOn)
            {
                ChangeStateAndNotify();
            } else if ((transform.position - closedTransform.position).magnitude <= movableObjectSO.precision &&
                       _isOn)
            {
                transform.position = closedTransform.position;
                ChangeStateAndNotify();
            }
        }

        protected override void TurnObjectOn(bool notify = true)
        {
            transform.position = openedTransform.position;
            _isOn = true;
            base.TurnObjectOn(notify);
        }

        protected override void TurnObjectOff(bool notify = true)
        {
            transform.position = closedTransform.position;
            _isOn = false;
            base.TurnObjectOff(notify);
        }

        /// <summary>
        /// Saves offset to dragable object on start drag
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <param name="dragableObject"></param>
        public void OnStartMove(Vector3 mousePosition, DragableObject dragableObject)
        {
            _offsetToObj = transform.position - GetMouseWorldPoint(mousePosition);
        }
        
        private Vector3 GetNewWorldPosition(Vector3 newMousePosition)
        {
            var pos = GetMouseWorldPoint(newMousePosition) + _offsetToObj;
            if (!allowMovementAlongAxisX)
            {
                pos = new Vector3(transform.position.x, pos.y, pos.z);
            }

            if (!allowMovementAlongAxisY)
            {
                pos = new Vector3(pos.x, transform.position.y, pos.z);
            }

            return pos;
        }

        private Vector3 GetMouseWorldPoint(Vector3 mousePosition)
        {
            var worldPos = _camera.ScreenToWorldPoint(new Vector3(
                mousePosition.x, mousePosition.y, _camera.nearClipPlane));
            return new Vector3(worldPos.x, worldPos.y, transform.position.z);
        }

        private float GetDistanceToStart()
        {
            return (transform.position - openedTransform.position).magnitude;
        }

        private void ChangeStateAndNotify()
        {
            _isOn = !_isOn;
            NotifyOnStateChanged();
        }

        /// <summary>
        /// Calculates extents to use in Physics.OverlapBoxNonAlloc
        /// </summary>
        private Bounds GetBoundBox()
        {
            _childrenColliders = GetComponentsInChildren<Collider>().ToList();
            if (_childrenColliders.Count == 0) return new Bounds(Vector3.zero, Vector3.zero);
            
            var bounds = _childrenColliders[0].bounds;
            foreach (var c in _childrenColliders)
            {
                bounds.Encapsulate(c.bounds);
            }
           
            return bounds;
        }

        /// <summary>
        /// Check if new position is overlapping with some other collider
        /// </summary>
        /// <param name="position">New object position</param>
        /// <returns>True if overlaps with other object, otherwise false</returns>
        private bool IsOverlapping(Vector3 position)
        {
            var size = Physics.OverlapBoxNonAlloc(position + _offsetToBoundsCenter, _bounds.extents, _overlapColliders, Quaternion.identity);
            if (checkOverlapWith.Count == 0)
            {
                for (var i = 0; i < size; i++)
                {
                    if (!_childrenColliders.Contains(_overlapColliders[i]))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return checkOverlapWith.Any(c => _overlapColliders.Contains(c));
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position + _offsetToBoundsCenter, _bounds.extents * 2);
        }
    }
}