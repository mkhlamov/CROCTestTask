using System;
using Models;
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
        /// <param name="gameData">Time, errors count and model type</param>
        public void UpdateResults(GameData gameData)
        {
            if (gameData.GameTime <= TimeSpan.MaxValue.TotalSeconds)
            {
                var ts = TimeSpan.FromSeconds(gameData.GameTime);
                timeText.text = ts.ToString(@"mm\.ss\:fff");
            }
            else
            {
                timeText.text = "Error!!!";
            }

            errorsText.text = gameData.ErrorsCount.ToString();
        }
    }
}