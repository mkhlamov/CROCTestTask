using UnityEngine;
using UnityEngine.EventSystems;

namespace Views.InteractableObjects
{
    public class DragableObject : BaseInteractableObject<DragableObjectParent>
    {
        private Vector3 _prevPos;

        private void OnMouseDrag()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            var offset = Input.mousePosition - _prevPos;
            Parent.OnDrag(new Vector2(offset.x / Screen.width, offset.y / Screen.height),
                Input.mousePosition, this);
            _prevPos = Input.mousePosition;
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            _prevPos = Input.mousePosition;
            Parent.OnStartDrag(_prevPos, this);
        }
    }
}