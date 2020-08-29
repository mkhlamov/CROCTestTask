using System;

namespace Views.InteractableObjects
{
    public class ClickableObjectsParent : BaseInteractableObjectParent
    {
        public Action onClick;
        public void OnClick() => onClick?.Invoke();
    }
}