using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _speed = 10f;

        private Vector2 _direction;
        private bool _isPlayerBullet;
        private BulletPool _pool;
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private bool _isInitialized;

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

        public void InitializePoolReference(BulletPool pool)
        {
            _pool = pool;
        }

        public void Initialize(Vector2 direction, bool isPlayerBullet, BulletPool pool)
        {
            _direction = direction.normalized;
            _isPlayerBullet = isPlayerBullet;
            _pool = pool;
            _isInitialized = true;

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
            _isPlayerBullet = false;

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
            if (!CanInteract())
                return;

            if (TryHandleBulletCollision(other))
                return;

            if (TryHandleBulletRemover(other))
                return;

            TryHandleDamage(other);
        }

        private bool CanInteract()
        {
            return _isInitialized;
        }

        private bool TryHandleBulletCollision(Collider2D other)
        {
            if (other.TryGetComponent(out Bullet otherBullet))
            {
                if (otherBullet._isPlayerBullet != _isPlayerBullet)
                {
                    otherBullet.ReturnToPool();
                    ReturnToPool();
                }

                return true;
            }

            return false;
        }

        private bool TryHandleBulletRemover(Collider2D other)
        {
            if (other.TryGetComponent(out BulletRemover remover))
            {
                ReturnToPool();
                return true;
            }

            return false;
        }

        private void TryHandleDamage(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                if (CanDamage(other))
                {
                    damageable.TakeDamage();
                    ReturnToPool();
                }
            }
        }

        private bool CanDamage(Collider2D other)
        {
            if (_isPlayerBullet && other.TryGetComponent(out Enemy.Enemy _))
                return true;

            if (!_isPlayerBullet && other.TryGetComponent(out Bird.Bird _))
                return true;

            return false;
        }

        private void ReturnToPool()
        {
            if (_pool != null)
            {
                _pool.PutObject(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            ReturnToPool();
        }
    }
}