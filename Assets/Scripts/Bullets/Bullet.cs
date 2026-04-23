using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _speed = 10f;

        private Vector2 _direction;
        private bool _isInitialized;
        private Rigidbody2D _rb;
        private Collider2D _collider;

        private void Awake()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();

            if (_rb == null)
            {
                _rb = gameObject.AddComponent<Rigidbody2D>();
            }

            _rb.gravityScale = 0f;
            _rb.isKinematic = true;

            if (_collider == null)
            {
                _collider = gameObject.AddComponent<BoxCollider2D>();
                _collider.isTrigger = true;
            }
        }

        public void Initialize(Vector2 direction, int layerIndex)
        {
            _direction = direction.normalized;
            _isInitialized = true;
            gameObject.layer = layerIndex;

            ResetPhysics();
            RotateToDirection();
            EnableCollider(true);
        }

        private void ResetPhysics()
        {
            if (_rb != null)
            {
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0f;
            }
        }

        private void RotateToDirection()
        {
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        public void ResetBullet()
        {
            _isInitialized = false;
            _direction = Vector2.zero;

            if (_rb != null)
            {
                _rb.velocity = Vector2.zero;
                _rb.isKinematic = true;
            }

            EnableCollider(false);
        }

        private void EnableCollider(bool enable)
        {
            if (_collider != null)
                _collider.enabled = enable;
        }

        private void Update()
        {
            if (!_isInitialized)
                return;

            Move();
        }

        private void Move()
        {
            Vector3 movement = _direction * _speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isInitialized)
                return;

            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage();
                gameObject.SetActive(false);
            }
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }
}