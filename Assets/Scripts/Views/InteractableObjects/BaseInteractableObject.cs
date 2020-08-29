using UnityEngine;

namespace Views.InteractableObjects
{
    public class BaseInteractableObject<T> : MonoBehaviour
        where T: BaseInteractableObjectParent 
    {
        protected T Parent;
        
        private void Start()
        {
            var parent = gameObject.transform.parent;
            while (parent.GetComponent<T>() == null)
            {
                parent = parent.parent;
            }

            Parent = parent.GetComponent<T>();
        }
    }
}