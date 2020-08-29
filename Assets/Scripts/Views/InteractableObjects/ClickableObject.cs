using UnityEngine.EventSystems;

namespace Views.InteractableObjects
{
    public class ClickableObject : BaseInteractableObject<ClickableObjectsParent>
    {
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            Parent.OnClick();
        }
    }
}