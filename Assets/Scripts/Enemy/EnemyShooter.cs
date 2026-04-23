using Assets.Scripts.Bullets;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private float _shootDelay;
        [SerializeField] private LayerMask _bulletLayer;
        private BulletPool _bulletPool;
        private Coroutine _shootCoroutine;
        private bool _isShooting;

        public void Init(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public void StartShooting()
        {
            if (_isShooting) return;

            _isShooting = true;
            _shootCoroutine = StartCoroutine(ShootRoutine());
        }

        public void StopShooting()
        {
            if (!_isShooting) return;

            _isShooting = false;

            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
                _shootCoroutine = null;
            }
        }

        private IEnumerator ShootRoutine()
        {
            var wait = new WaitForSeconds(_shootDelay);

            while (_isShooting)
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
            int layerIndex = (int)Mathf.Log(_bulletLayer.value, 2);
            bullet.Initialize(Vector2.left, layerIndex);
            bullet.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            StopShooting();
        }
    }
}