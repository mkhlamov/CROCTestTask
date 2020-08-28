using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Scenario", menuName = "Scenario")]
    public class Scenario : ScriptableObject
    {
        public Sprite previewImage;
        public string modelName;
        public GameObject modelPrefab;
        public List<DevicePartState> deviceStates;
        public ModelDefaultState modelDefaultState;
    }
    
    [Serializable]
    public class DevicePartState
    {
        public string deviceName;
        public bool state;

        public override string ToString()
        {
            string StateToStr(bool e)
            {
                return e ? "on" : "off";
            }

            return $"Turn {deviceName} {StateToStr(state)}";
        }
    }
}