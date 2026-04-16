using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Transform _container;

        private Queue<Enemy> _pool;

        private void Awake()
        {
            _pool = new Queue<Enemy>();
        }

        public Enemy GetObject()
        {
            if (_pool.Count == 0)
            {
                Enemy enemy = Instantiate(_prefab, _container);
                enemy.Died += OnEnemyDied;
                return enemy;
            }

            Enemy pooled = _pool.Dequeue();
            pooled.Died += OnEnemyDied;
            return pooled;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            PutObject(enemy);
        }

        public void PutObject(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            _pool.Enqueue(enemy);
        }
    }
}
