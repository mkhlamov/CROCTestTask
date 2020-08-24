using UnityEngine;

namespace Views.UI
{
    /// <summary>
    /// Base class for UI roots
    /// </summary>
    public abstract class UIRoot : MonoBehaviour
    {
        /// <summary>
        /// Shows UI Root
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides UI Root
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}