using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnDelay = 2f;

    private void Start()
    {
        if (_spawnPoints.Count > 0)
        {
            StartCoroutine(SpawnRoutine());
        }
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
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        _spawnPoints[randomIndex].Spawn();
    }
}
