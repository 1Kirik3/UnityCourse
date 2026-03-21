using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Core
{
    public abstract class BaseSpawner<T> : MonoBehaviour, IStatProvider where T : MonoBehaviour
    {
        [Header("Pool Config")]
        [SerializeField] private T _prefab;
        [SerializeField] private int _defaultCapacity = 10;
        [SerializeField] private int _maxSize = 20;

        private ObjectPool<T> _pool;

        public int TotalSpawned { get; private set; }
        public int TotalCreated { get; private set; }
        public int ActiveCount => _pool.CountActive;

        protected virtual void Awake()
        {
            _pool = new ObjectPool<T>(
                createFunc: () => {
                    TotalCreated++;
                    return Instantiate(_prefab);
                },
                actionOnGet: (obj) => {
                    obj.gameObject.SetActive(true);
                    TotalSpawned++;
                },
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj.gameObject),
                collectionCheck: true,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
        }

        public T Get() => _pool.Get();
        public virtual void Release(T obj) => _pool.Release(obj);
    }
}


