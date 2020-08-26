using System;
using UnityEngine;

namespace Views
{
    public class DragableObjectParent : MonoBehaviour
    {
        public Action<Vector2, Vector3, DragableObject> onDrag;
        public Action<Vector3, DragableObject> onMouseDown;

        public void OnDrag(Vector2 offset, Vector3 newMousePosition, DragableObject dragableObject) 
            => onDrag?.Invoke(offset, newMousePosition, dragableObject);

        public void OnStartDrag(Vector3 newMousePosition, DragableObject dragableObject) 
            => onMouseDown?.Invoke(newMousePosition, dragableObject);
    }
}