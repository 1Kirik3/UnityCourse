using Assets.Scripts.Bullets;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public event Action<Enemy> EnemySpawned;
        [SerializeField] private float _delay;
        [SerializeField] private float _lowerBound;
        [SerializeField] private float _upperBound;
        [SerializeField] private EnemyPool _pool;
        [SerializeField] private BulletPool _bulletPool;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                Spawn();
                yield return wait;
            }
        }

        private void Spawn()
        {
            float spawnY = UnityEngine.Random.Range(_upperBound, _lowerBound);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnY, transform.position.z);
            Enemy enemy = _pool.GetObject();
            enemy.transform.position = spawnPoint;
            enemy.Init(_bulletPool);
            enemy.Activate();
            EnemySpawned?.Invoke(enemy);
        }
    }
}
