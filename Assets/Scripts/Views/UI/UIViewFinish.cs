using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class UIViewFinish : UIView
    {
        public Action onMenuButtonClicked;
        [SerializeField] private Text timeText;
        [SerializeField] private Text errorsText;

        public void MenuButtonClicked() => onMenuButtonClicked?.Invoke();

        /// <summary>
        /// Updates result texts of training
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <param name="errors">Number of errors</param>
        public void UpdateResults(float time, int errors)
        {
            if (time <= TimeSpan.MaxValue.TotalSeconds)
            {
                var ts = TimeSpan.FromSeconds(time);
                timeText.text = ts.ToString(@"mm\.ss\:fff");
            }
            else
            {
                timeText.text = "Error!!!";
            }

            errorsText.text = errors.ToString();
        }
    }
}