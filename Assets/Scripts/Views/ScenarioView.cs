using System;
using Models.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScenarioView : MonoBehaviour
    {
        public Button button;
        public Text scenarioName;
        public Image itemIcon;

        private Scenario _scenario;
        
        /// <summary>
        /// Initialize view for scenario
        /// </summary>
        /// <param name="data">scenario scriptable object</param>
        /// <param name="callback">action on click</param>
        public void Init(Scenario data, Action<Scenario> callback)
        {
            _scenario = data;
            scenarioName.text = _scenario.modelName;
            itemIcon.sprite = _scenario.previewImage;
            itemIcon.preserveAspect = true;

            button.onClick.AddListener(() => callback(data) );
        }
    }
}