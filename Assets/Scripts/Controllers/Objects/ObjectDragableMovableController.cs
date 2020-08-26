using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Views;

namespace Controllers.Objects
{
    public class ObjectDragableMovableController : MonoBehaviour
    {
        private List<MovableObjectView> _dragableMovableObjects;
        private void Awake()
        {
            _dragableMovableObjects = FindObjectsOfType<MovableObjectView>().ToList();
        }

        private void OnEnable()
        {
            foreach (var obj in _dragableMovableObjects)
            {
                obj.Parent.onDrag += obj.Move;
                obj.Parent.onMouseDown += obj.OnStartMove;
            }
        }
        
        private void OnDisable()
        {
            foreach (var obj in _dragableMovableObjects.Where(obj => obj != null))
            {
                obj.Parent.onDrag -= obj.Move;
                obj.Parent.onMouseDown -= obj.OnStartMove;
            }
        }
    }
}