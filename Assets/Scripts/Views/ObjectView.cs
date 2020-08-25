using UnityEngine;

namespace Views
{
    /// <summary>
    /// Base class for object views
    /// </summary>
    public class ObjectView : MonoBehaviour
    {
        protected bool _isOn = true;
        public bool IsOn => _isOn;
        
        /// <summary>
        /// Shows Object View
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides Object View
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}