using System;
using UnityEngine;

namespace Views
{
    public class DragableObjectParent : MonoBehaviour
    {
        public Action<Vector2> onDrag;

        public void OnDrag(Vector2 offset) => onDrag?.Invoke(offset);
    }
}