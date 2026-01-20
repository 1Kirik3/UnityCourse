using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private float _spawnDelay = 0.5f;
    [SerializeField] private float _spawnRadius = 5f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        Cube cube = _pool.Get();
        cube.transform.position = GetRandomSpawnPoint();
        cube.transform.rotation = Quaternion.identity;

        if (cube.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-_spawnRadius, _spawnRadius),
            0,
            Random.Range(-_spawnRadius, _spawnRadius)
        );

        return _spawnArea.position + randomOffset;
    }
}
