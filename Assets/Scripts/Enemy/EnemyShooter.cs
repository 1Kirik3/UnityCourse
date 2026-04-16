using Assets.Scripts.Bullets;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private float _shootDelay;
        private BulletPool _bulletPool;

        public void Init(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        private void Start()
        {
            StartCoroutine(ShootRoutine());
        }

        private IEnumerator ShootRoutine()
        {
            var wait = new WaitForSeconds(_shootDelay);

            while (enabled)
            {
                yield return wait;
                Shoot();
            }
        }

        private void Shoot()
        {
            if (_bulletPool == null) 
                return;

            Bullet bullet = _bulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.Initialize(Vector2.left, false, _bulletPool);
            bullet.gameObject.SetActive(true);
        }
    }
}
