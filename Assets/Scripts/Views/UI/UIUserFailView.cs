using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class UIUserFailView : UIView
    {
        [SerializeField] private Text errorText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button continueButton;

        private Action _restartCallback;
        private Action _continueCallback;

        public void Init(string errorString, Action restartCallback, Action continueCallback)
        {
            errorText.text = errorString;
            _restartCallback = restartCallback;
            _continueCallback = continueCallback;
            restartButton.onClick.AddListener(() => _restartCallback?.Invoke());
            continueButton.onClick.AddListener(() => _continueCallback?.Invoke());
        }

        public void Finalize()
        {
            errorText.text = string.Empty;
            restartButton.onClick.RemoveListener(() => _restartCallback?.Invoke());
            continueButton.onClick.RemoveListener(() => _continueCallback?.Invoke());
        }
    }
}