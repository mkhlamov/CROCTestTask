using System;
using UnityEngine;

namespace Views
{
    public class ClickableObjectsParent : MonoBehaviour
    {
        public Action onClick;
        public void OnClick() => onClick?.Invoke();
    }
}