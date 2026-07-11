using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Core.ResourcesLogic
{
    public class ResourcePool : MonoBehaviour
    {
        [SerializeField] private Resource _prefab;
        [SerializeField] private int _defaultCapacity = 10;
        [SerializeField] private int _maxSize = 50;

        private IObjectPool<Resource> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Resource>(
                createFunc: CreateInstance,
                actionOnGet: OnTakeFromPool,
                actionOnRelease: OnReturnedToPool,
                actionOnDestroy: OnDestroyPoolObject,
                collectionCheck: true,
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
            return Instantiate(_prefab);
        }

        private void OnTakeFromPool(Resource resource)
        {
            resource.gameObject.SetActive(true);
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
