using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Transform _container;

        private Queue<Enemy> _pool;
        private List<Enemy> _allEnemies;

        private void Awake()
        {
            _pool = new Queue<Enemy>();
            _allEnemies = new List<Enemy>();
        }

        public Enemy GetObject()
        {
            Enemy enemy;

            if (_pool.Count == 0)
            {
                enemy = Instantiate(_prefab, _container);
                enemy.Died += OnEnemyDied;
                _allEnemies.Add(enemy);
            }
            else
            {
                enemy = _pool.Dequeue();
                enemy.Died += OnEnemyDied;
            }

            return enemy;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            PutObject(enemy);
        }

        public void PutObject(Enemy enemy)
        {
            enemy.Deactivate();
            enemy.transform.SetParent(_container);
            enemy.transform.position = Vector3.zero;
            _pool.Enqueue(enemy);
        }

        public void Reset()
        {
            foreach (var enemy in _allEnemies)
            {
                if (enemy != null)
                {
                    if (enemy.gameObject.activeSelf)
                    {
                        enemy.Died -= OnEnemyDied;
                        enemy.Deactivate();
                    }
                    enemy.transform.SetParent(_container);
                    enemy.transform.position = Vector3.zero;
                    _pool.Enqueue(enemy);
                }
            }

            _pool.Clear();

            foreach (var enemy in _allEnemies)
            {
                if (enemy != null)
                    _pool.Enqueue(enemy);
            }
        }

        private void OnDestroy()
        {
            foreach (var enemy in _allEnemies)
            {
                if (enemy != null)
                    Destroy(enemy.gameObject);
            }

            _allEnemies.Clear();
            _pool.Clear();
        }
    }
}