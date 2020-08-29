using UnityEngine;
using UnityEngine.EventSystems;

namespace Views
{
    public class DragableObject : MonoBehaviour
    {
        private DragableObjectParent _parent;
        
        private void Start()
        {
            _parent = gameObject.transform.parent.GetComponent<DragableObjectParent>();
        }

        private Vector3 _prevPos;

        private void OnMouseDrag()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            var offset = Input.mousePosition - _prevPos;
            _parent.OnDrag(new Vector2(offset.x / Screen.width, offset.y / Screen.height),
                Input.mousePosition, this);
            _prevPos = Input.mousePosition;
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            _prevPos = Input.mousePosition;
            _parent.OnStartDrag(_prevPos, this);
        }
    }
}