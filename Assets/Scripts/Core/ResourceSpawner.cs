using UnityEngine;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(ResourcePool))]
    public class ResourceSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ResourcePool _resourcePool;

        [Header("Spawn Settings")]
        [SerializeField] private float _spawnInterval = 3f;
        [SerializeField] private Vector2 _spawnAreaSize = new Vector2(20f, 20f);
        [SerializeField] private float _spawnHeightOffset = 0.5f;

        private float _timer;

        private void Awake()
        {
            if (_resourcePool == null)
            {
                _resourcePool = GetComponent<ResourcePool>();
            }
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _spawnInterval)
            {
                _timer = 0f;
                SpawnResource();
            }
        }

        private void SpawnResource()
        {
            Resource resource = _resourcePool.Get();

            Vector3 randomPosition = new Vector3(
                Random.Range(-_spawnAreaSize.x / 2f, _spawnAreaSize.x / 2f),
                _spawnHeightOffset,
                Random.Range(-_spawnAreaSize.y / 2f, _spawnAreaSize.y / 2f)
            ) + transform.position;

            resource.transform.position = randomPosition;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Vector3 center = transform.position + Vector3.up * _spawnHeightOffset;
            Gizmos.DrawWireCube(center, new Vector3(_spawnAreaSize.x, 0.1f, _spawnAreaSize.y));
        }
    }
}
