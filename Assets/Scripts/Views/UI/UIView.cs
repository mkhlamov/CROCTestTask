using UnityEngine;

namespace Views.UI
{
    /// <summary>
    /// Base class for UI views
    /// </summary>
    public class UIView : MonoBehaviour
    {
        /// <summary>
        /// Shows UI View
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides UI View
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
