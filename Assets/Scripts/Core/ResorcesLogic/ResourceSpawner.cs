using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.ResourcesLogic
{
    [RequireComponent(typeof(ResourcePool))]
    public class ResourceSpawner : MonoBehaviour
    {
        [SerializeField] private ResourcePool _resourcePool;
        [SerializeField] private float _spawnInterval = 3f;
        [SerializeField] private Vector2 _spawnAreaSize = new Vector2(20f, 20f);
        [SerializeField] private float _spawnHeightOffset = 0.5f;

        private void Awake()
        {
            if (_resourcePool == null)
            {
                _resourcePool = GetComponent<ResourcePool>();
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            var waitInterval = new WaitForSeconds(_spawnInterval);

            while (true)
            {
                yield return waitInterval;
                SpawnResource();
            }
        }

        private void SpawnResource()
        {
            Resource resource = _resourcePool.Get();
            resource.ResetState();

            Vector3 randomPosition = new Vector3(
                Random.Range(-_spawnAreaSize.x / 2f, _spawnAreaSize.x / 2f),
                _spawnHeightOffset,
                Random.Range(-_spawnAreaSize.y / 2f, _spawnAreaSize.y / 2f)
            ) + transform.position;

            resource.transform.position = randomPosition;

            resource.Collected += HandleResourceCollected;
        }

        private void HandleResourceCollected(IResource resource)
        {
            resource.Collected -= HandleResourceCollected;

            if (resource is Resource poolableResource)
            {
                _resourcePool.Release(poolableResource);
            }
        }
    }
}
