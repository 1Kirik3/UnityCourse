// BaseSpawner.cs
using System;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Core
{
    public abstract class BaseSpawner<T> : MonoBehaviour, IStatProvider where T : MonoBehaviour, IPoolable
    {
        [Header("Pool Config")]
        [SerializeField] protected T _prefab;
        [SerializeField] private int _defaultCapacity = 10;
        [SerializeField] private int _maxSize = 20;

        private ObjectPool<T> _pool;

        public event Action OnStatsChanged;

        public int TotalSpawned { get; protected set; }
        public int TotalCreated { get; protected set; }
        public int ActiveCount
        {
            get => _pool?.CountActive ?? 0;
        }

        protected virtual void Awake()
        {
            _pool = new ObjectPool<T>(
                createFunc: CreateObject,
                actionOnGet: OnGetObject,
                actionOnRelease: OnReleaseObject,
                actionOnDestroy: OnDestroyObject,
                collectionCheck: true,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
        }

        protected virtual T CreateObject()
        {
            TotalCreated++;
            OnStatsChanged?.Invoke();
            return Instantiate(_prefab);
        }

        protected virtual void OnGetObject(T obj)
        {
            obj.gameObject.SetActive(true);
            obj.ResetState();
            TotalSpawned++;
            OnStatsChanged?.Invoke();
        }

        protected virtual void OnReleaseObject(T obj)
        {
            obj.gameObject.SetActive(false);
            OnStatsChanged?.Invoke();
        }

        protected virtual void OnDestroyObject(T obj)
        {
            Destroy(obj.gameObject);
        }

        protected void RaiseStatsChanged()
        {
            OnStatsChanged?.Invoke();
        }

        public T Get()
        {
            return _pool.Get();
        }

        public virtual void Release(T obj)
        {
            _pool.Release(obj);
        }
    }
}