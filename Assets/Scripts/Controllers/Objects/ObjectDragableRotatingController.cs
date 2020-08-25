using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Views;

namespace Controllers.Objects
{
    public class ObjectDragableRotatingController : MonoBehaviour
    {
        private List<RotatableObjectView> _dragableRotatingObjects;
        private void Awake()
        {
            _dragableRotatingObjects = FindObjectsOfType<RotatableObjectView>().ToList();
        }

        private void OnEnable()
        {
            foreach (var obj in _dragableRotatingObjects)
            {
                obj.Parent.onDrag += obj.Rotate;
            }
        }
        
        private void OnDisable()
        {
            foreach (var obj in _dragableRotatingObjects)
            {
                obj.Parent.onDrag -= obj.Rotate;
            }
        }
    }
}