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
    }
    
    [Serializable]
    public class DevicePartState
    {
        public DevicePart devicePart;
        public bool state;
    }
}