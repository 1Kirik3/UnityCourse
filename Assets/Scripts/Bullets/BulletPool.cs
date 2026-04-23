using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private int _initialPoolSize = 10;
        [SerializeField] private Transform _container;

        private Queue<Bullet> _pool;
        private List<Bullet> _allBullets;

        private void Awake()
        {
            _pool = new Queue<Bullet>();
            _allBullets = new List<Bullet>();

            if (_container == null)
            {
                _container = transform;
            }

            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                CreateNewBullet();
            }
        }

        private void CreateNewBullet()
        {
            Bullet bullet = Instantiate(_prefab, _container);
            bullet.gameObject.SetActive(false);
            _pool.Enqueue(bullet);
            _allBullets.Add(bullet);
        }

        public Bullet GetObject()
        {
            if (_pool.Count == 0)
            {
                CreateNewBullet();
            }

            Bullet bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }

        public void PutObject(Bullet bullet)
        {
            if (bullet == null)
                return;

            bullet.ResetBullet();
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(_container);
            bullet.transform.position = Vector3.zero;
            _pool.Enqueue(bullet);
        }

        public void Reset()
        {
            foreach (var bullet in _allBullets)
            {
                if (bullet != null && bullet.gameObject.activeSelf)
                {
                    bullet.ResetBullet();
                    bullet.gameObject.SetActive(false);
                    bullet.transform.SetParent(_container);
                    bullet.transform.position = Vector3.zero;
                }
            }

            _pool.Clear();

            foreach (var bullet in _allBullets)
            {
                if (bullet != null)
                    _pool.Enqueue(bullet);
            }
        }

        private void OnDestroy()
        {
            foreach (var bullet in _allBullets)
            {
                if (bullet != null)
                    Destroy(bullet.gameObject);
            }

            _allBullets.Clear();
            _pool.Clear();
        }
    }
}