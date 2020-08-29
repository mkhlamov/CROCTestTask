using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Views
{
    public class ClickableObject : MonoBehaviour
    {
        private ClickableObjectsParent _parent;

        private void Start()
        {
            _parent = gameObject.transform.parent.GetComponent<ClickableObjectsParent>();
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            _parent.OnClick();
        }
    }
}