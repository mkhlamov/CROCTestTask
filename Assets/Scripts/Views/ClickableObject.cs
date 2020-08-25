using System;
using UnityEngine;

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
            _parent.OnClick();
        }
    }
}