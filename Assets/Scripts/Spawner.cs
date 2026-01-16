using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private Transform _spawnPosition;

    private const int _minSpawnCount = 2;
    private const int _maxSpawnCount = 6;

    public List<Cube> SpawnMultiple()
    {
        List<Cube> newCubes = new List<Cube>();
        var spawnCount = Random.Range(_minSpawnCount, _maxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            var cube = Spawn();
            newCubes.Add(cube);
        }

        return newCubes;
    }

    public Cube Spawn()
    {
        return Instantiate(_cube, _spawnPosition.position, Quaternion.identity)?.GetComponent<Cube>();
    }
}
