using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _container;

        private Queue<Bullet> _pool;

        private void Awake()
        {
            _pool = new Queue<Bullet>();
        }

        public Bullet GetObject()
        {
            if (_pool.Count == 0)
            {
                Bullet bullet = Instantiate(_prefab, _container);
                return bullet;
            }

            return _pool.Dequeue();
        }

        public void PutObject(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _pool.Enqueue(bullet);
        }
    }
}
