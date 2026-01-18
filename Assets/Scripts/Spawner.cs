using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinSpawnCount = 2;
    private const int MaxSpawnCount = 6;

    [SerializeField] private Cube _cube;

    public List<Cube> SpawnMultiple(Vector3 spawnPoint)
    {
        List<Cube> newCubes = new List<Cube>();
        var spawnCount = Random.Range(MinSpawnCount, MaxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            var cube = Spawn(spawnPoint);
            newCubes.Add(cube);
        }

        return newCubes;
    }

    public Cube Spawn(Vector3 spawnPoint)
    {
        return Instantiate(_cube, spawnPoint, Quaternion.identity);
    }
}
