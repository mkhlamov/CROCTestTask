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

        private Camera _camera => Camera.main;
        private Vector3 _offsetToObj;
        private Vector3 _startPosition;
        
        private void OnEnable()
        {
            Parent.onDrag += Move;
            Parent.onMouseDown += OnStartMove;
            _startPosition = transform.position;
            _isOn = GetDistanceToStart() < movableObjectSO.distanceToClosed;
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
            var pos = GetMouseWorldPoint(newMousePosition) + _offsetToObj;
            if (!allowMovementAlongAxisX)
            {
                pos = new Vector3(transform.position.x, pos.y, pos.z);
            }

            if (!allowMovementAlongAxisY)
            {
                pos = new Vector3(pos.x, transform.position.y, pos.z);
            }

            transform.position = pos;

            if (((transform.position - _startPosition).magnitude >= movableObjectSO.distanceToClosed && !_isOn) ||
                ((transform.position - _startPosition).magnitude < movableObjectSO.distanceToClosed && _isOn))
            {
                _isOn = !_isOn;
                NotifyOnStateChanged();
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

        private Vector3 GetMouseWorldPoint(Vector3 mousePosition)
        {
            var worldPos = _camera.ScreenToWorldPoint(new Vector3(
                mousePosition.x, mousePosition.y, _camera.nearClipPlane));
            return new Vector3(worldPos.x, worldPos.y, transform.position.z);
        }

        private float GetDistanceToStart()
        {
            return (transform.position - _startPosition).magnitude;
        }
    }
}