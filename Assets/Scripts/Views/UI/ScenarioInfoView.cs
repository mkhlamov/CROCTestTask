using System.Collections.Generic;
using System.Text;
using Models.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class ScenarioInfoView : MonoBehaviour
    {
        [SerializeField] public Text hint;

        public void Init(List<DevicePartState> scenarioSteps)
        {
            var res = new StringBuilder();
            for (var i = 0; i < scenarioSteps.Count; i++)
            {
                res.AppendLine($"{i + 1}. {scenarioSteps[i].ToString()}");
            }

            hint.text = res.ToString();
        }
    }
}