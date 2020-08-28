using System.Collections.Generic;
using System.Text;
using Models.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScenarioInfoView : MonoBehaviour
    {
        [SerializeField] public Text hint;

        public void Init(List<DevicePartState> scenarioSteps)
        {
            string StateToStr(bool e)
            {
                return e ? "on" : "off";
            }
            
            var res = new StringBuilder();
            for (var i = 0; i < scenarioSteps.Count; i++)
            {
                res.AppendLine($"{i + 1}. Turn {scenarioSteps[i].deviceName} {StateToStr(scenarioSteps[i].state)}");
            }

            hint.text = res.ToString();
        }
    }
}