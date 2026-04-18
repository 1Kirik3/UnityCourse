using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private float _offsetZ = -10f;
        [SerializeField] private float _fixedY = 0f;
        [SerializeField] private float _cameraOffsetX = 6f;

        private Vector3 _startPosition;
        private float _targetX;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void LateUpdate()
        {
            if (_target == null) 
                return;

            float desiredX = _target.position.x + _cameraOffsetX;

            if (desiredX > transform.position.x)
            {
                _targetX = desiredX;
            }

            Vector3 smoothedPosition = new Vector3(
                Mathf.Lerp(transform.position.x, _targetX, _smoothSpeed),
                _fixedY,
                _offsetZ
            );

            transform.position = smoothedPosition;
        }

        public void ResetPosition()
        {
            transform.position = _target.position;
        }
    }
}

