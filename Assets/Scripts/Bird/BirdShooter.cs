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
            Bullet bullet = _bulletPool.GetObject();
            Vector2 shootDirection = _bird.transform.right;

            if (_shootPoint != null)
                bullet.transform.position = _shootPoint.position;
            else
                bullet.transform.position = _bird.transform.position;

            bullet.Initialize(shootDirection, true, _bulletPool);
            bullet.gameObject.SetActive(true);
        }
    }
}
