using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class UIViewGame : UIView
    {
        public Action onFinish;
        [SerializeField] private Text timeText;

        /// <summary>
        /// Invokes action after finish 
        /// </summary>
        public void Finished()
        {
            onFinish?.Invoke();
        }
        
        /// <summary>
        /// Updates time text
        /// </summary>
        /// <param name="time">Time in seconds</param>
        public void UpdateTime(float time)
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
        }
    }
}