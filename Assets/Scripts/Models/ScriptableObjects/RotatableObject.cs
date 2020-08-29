using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewRotatable", menuName = "Rotatable Object")]
    public class RotatableObject : ScriptableObject
    {
        [Range(-360, 360)]
        public float minAngle;
        [Range(-360, 360)]
        public float maxAngle;
        
        [Range(-360, 360)]
        public float openedAngle;
        [Range(-360, 360)]
        public float closedAngle;

        public RotationAxis rotationAxis;
    }
    
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }
}