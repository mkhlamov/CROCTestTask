using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "new DevicePart", menuName = "DevicePart")]
    public class DevicePart : ScriptableObject
    {
        public string deviceName;
        public bool startState;
    }
}