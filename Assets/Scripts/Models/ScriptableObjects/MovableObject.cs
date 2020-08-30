using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new MovableObject", menuName = "MovableObject")]
    public class MovableObject : ScriptableObject
    {
        public float distanceToOpened;
        public float precision;
    }
}