using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(DragableObjectParent))]
    public class MovableObjectView : ObjectView
    {
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

        /// <summary>
        /// Moves parent object when dragableObject is dragged
        /// </summary>
        /// <param name="offset">Mouse offset</param>
        /// <param name="newMousePosition"></param>
        /// <param name="dragableObject">Object being dragged by user</param>
        public void Move(Vector2 offset, Vector3 newMousePosition, DragableObject dragableObject)
        {
            transform.position = GetMouseWorldPoint(newMousePosition) + _offsetToObj;
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
            return _camera.ScreenToWorldPoint(new Vector3(
                mousePosition.x, mousePosition.y, _camera.nearClipPlane));
        }
    }
}