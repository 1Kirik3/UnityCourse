using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Core
{
    public class ResourcePool : MonoBehaviour
    {
        [SerializeField] private Resource _prefab;
        [SerializeField] private int _defaultCapacity = 10;
        [SerializeField] private int _maxSize = 50;
        [SerializeField] private bool _collectionCheck = true;

        private IObjectPool<Resource> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Resource>(
                createFunc: CreateInstance,
                actionOnGet: OnTakeFromPool,
                actionOnRelease: OnReturnedToPool,
                actionOnDestroy: OnDestroyPoolObject,
                collectionCheck: _collectionCheck,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
        }

        public Resource Get()
        {
            return _pool.Get();
        }
        public void Release(Resource resource)
        {
            _pool.Release(resource);
        }

        private Resource CreateInstance()
        {
            Resource instance = Instantiate(_prefab);
            return instance;
        }

        private void OnTakeFromPool(Resource resource)
        {
            resource.gameObject.SetActive(true);
            resource.Initialize(Release);
        }

        private void OnReturnedToPool(Resource resource)
        {
            resource.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(Resource resource)
        {
            if (resource != null)
            {
                Destroy(resource.gameObject);
            }
        }
    }
}
