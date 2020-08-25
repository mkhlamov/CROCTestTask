using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewRotatable", menuName = "Rotatable Object")]
    public class RotatableObject : ScriptableObject
    {
        [Range(-360, 360)]
        public float maxAngle;
        [Range(-360, 360)]
        public float minAngle;
    }
}