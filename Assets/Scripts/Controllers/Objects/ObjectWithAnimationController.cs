using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Views;

namespace Controllers.Objects
{
    public class ObjectWithAnimationController : MonoBehaviour
    {
        private List<ObjectWithAnimationView> _objectWithAnimationViews;
        private void Awake()
        {
            _objectWithAnimationViews = FindObjectsOfType<ObjectWithAnimationView>().ToList();
        }

        private void OnEnable()
        {
            foreach (var obj in _objectWithAnimationViews)
            {
                obj.Parent.onClick += obj.ToggleObject;
            }
        }

        private void OnDisable()
        {
            foreach (var obj in _objectWithAnimationViews.Where(obj => obj != null))
            {
                obj.Parent.onClick -= obj.ToggleObject;
            }
        }
    }
}