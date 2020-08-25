using Models.ScriptableObjects;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(DragableObjectParent))]
    public class RotatableObjectView : ObjectView
    {
        [SerializeField] private RotatableObject rotatableObjectSO;
        private DragableObjectParent _parent;
        public DragableObjectParent Parent => _parent;

        private float _currentRotation = 0f;
        
        private void Awake()
        {
            _parent = GetComponent<DragableObjectParent>();
        }

        public void Rotate(Vector2 offset)
        {
            _currentRotation -= Time.deltaTime * offset.x * 10000;
            _currentRotation = Mathf.Clamp(_currentRotation, rotatableObjectSO.minAngle, rotatableObjectSO.maxAngle); 
            
            if (_currentRotation > 0) Debug.Log(_currentRotation);
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, _currentRotation, transform.rotation.z);
        }
    }
}