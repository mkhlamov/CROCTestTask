using System.Collections.Generic;
using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new ModelDefaultState", menuName = "ModelDefaultState")]
    public class ModelDefaultState : ScriptableObject
    {
        public List<DevicePartState> deviceStates;
    }
}