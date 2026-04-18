using Assets.Scripts.Bullets;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Bird
{
    [RequireComponent(typeof(Bird))]
    public class BirdShooter : MonoBehaviour
    {
        [SerializeField] private InputHandler _input;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _bulletOffset = 0.5f;

        private Bird _bird;

        private void Awake()
        {
            _bird = GetComponent<Bird>();
        }

        private void OnEnable()
        {
            if (_input != null)
                _input.ShootPressed += OnShoot;
        }

        private void OnDisable()
        {
            if (_input != null)
                _input.ShootPressed -= OnShoot;
        }

        private void OnShoot()
        {
            if (_bulletPool == null)
            {
                Debug.LogError("BulletPool is not assigned!");
                return;
            }

            Bullet bullet = _bulletPool.GetObject();

            if (bullet == null)
            {
                Debug.LogError("Failed to get bullet from pool!");
                return;
            }

            Vector2 shootDirection = _bird.transform.right;
            Vector2 spawnPosition;

            if (_shootPoint != null)
                spawnPosition = (Vector2)_shootPoint.position + shootDirection * _bulletOffset;
            else
                spawnPosition = (Vector2)_bird.transform.position + shootDirection * _bulletOffset;

            bullet.transform.position = spawnPosition;
            bullet.Initialize(shootDirection, true, _bulletPool);
        }
    }
}