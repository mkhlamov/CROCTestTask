using UnityEngine;

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
            var offset = Input.mousePosition - _prevPos;
            _parent.OnDrag(new Vector2(offset.x / Screen.width, offset.y / Screen.height));
            _prevPos = Input.mousePosition;
        }

        private void OnMouseDown()
        {
            _prevPos = Input.mousePosition;
        }
    }
}