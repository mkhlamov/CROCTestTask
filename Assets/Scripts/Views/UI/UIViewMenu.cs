using System;
using UnityEngine;

namespace Views.UI
{
    public class UIViewMenu : UIView
    {
        public Action onQuitButtonClicked;

        /// <summary>
        /// Invokes action after clicking quit button
        /// </summary>
        public void QuitButtonClicked() => onQuitButtonClicked?.Invoke();
    }
}