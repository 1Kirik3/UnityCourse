using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnDelay = 2f;

    private DirectionGenerator _directionGenerator;

    private void Awake()
    {
        _directionGenerator = new DirectionGenerator();
    }

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
        Transform randomPoint = GetRandomSpawnPoint();
        Vector3 direction = _directionGenerator.GetRandomHorizontalDirection();

        Enemy enemy = Instantiate(_enemyPrefab, randomPoint.position, Quaternion.identity);
        enemy.Initialize(direction);
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[randomIndex];
    }
}
