using System;
using UnityEngine;

namespace Views.UI
{
    public class UIViewMenu : UIView
    {
        public Action onModel1ButtonClicked;
        public Action onModel2ButtonClicked;
        public Action onQuitButtonClicked;

        /// <summary>
        /// Invokes action after choosing model 1 
        /// </summary>
        public void Model1Chosen()
        {
            onModel1ButtonClicked?.Invoke();
        }
        
        /// <summary>
        /// Invokes action after choosing model 2 
        /// </summary>
        public void Model2Chosen()
        {
            onModel2ButtonClicked?.Invoke();
        }

        /// <summary>
        /// Invokes action after clicking quit button
        /// </summary>
        public void QuitButtonClicked()
        {
            onQuitButtonClicked?.Invoke();
        }
    }
}