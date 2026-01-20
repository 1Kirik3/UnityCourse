using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinSpawnCount = 2;
    private const int MaxSpawnCount = 6;
    private const float ScaleFactor = 0.5f;

    private const int SpawnGenerationStep = 1;
    private const float SplitChanceDivider = 2f;

    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ColorChanger _colorChanger;

    public List<Cube> SpawnSplittedCubes(Cube parentCube)
    {
        int count = Random.Range(MinSpawnCount, MaxSpawnCount);
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parentCube.transform.position, Quaternion.identity);

            int nextGeneration = parentCube.SpawnGeneration + SpawnGenerationStep;
            float nextSplitChance = parentCube.SplitChance / SplitChanceDivider;
            float nextScale = parentCube.transform.localScale.x * ScaleFactor;

            newCube.Initialize(nextGeneration, nextSplitChance, nextScale);
            _colorChanger.ChangeColor(newCube.Renderer);

            newCubes.Add(newCube);
        }

        return newCubes;
    }

    public void CreateInitialCubes(Vector3 position)
    {
        int count = Random.Range(MinSpawnCount, MaxSpawnCount);

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity);
            _colorChanger.ChangeColor(newCube.Renderer);
        }
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}