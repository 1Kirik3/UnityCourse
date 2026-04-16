using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _speed;
        private Vector2 _direction;
        private bool _isPlayerBullet;
        private BulletPool _pool;

        public void Initialize(Vector2 direction, bool isPlayerBullet, BulletPool pool)
        {
            _direction = direction;
            _isPlayerBullet = isPlayerBullet;
            _pool = pool;
        }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy.Enemy enemy))
            {
                if (_isPlayerBullet)
                {
                    enemy.Die();
                    ReturnToPool();
                }
            }
            else if (other.TryGetComponent(out Bird.Bird bird))
            {
                if (!_isPlayerBullet)
                    bird.Die();

                ReturnToPool();
            }
            else if (other.TryGetComponent(out BulletRemover remover))
            {
                ReturnToPool();
            }
        }

        private void ReturnToPool()
        {
            _pool.PutObject(this);
        }
    }
}
