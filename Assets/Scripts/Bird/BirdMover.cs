using UnityEngine;

namespace Assets.Scripts.Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _tapForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;

        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Rigidbody2D _rigidbody2D;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Start()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            Reset();
        }

        private void Update()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        public void Fly()
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        public void Reset()
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0f;
            transform.position = _startPosition;
            transform.rotation = _startRotation;
        }
    }
}

