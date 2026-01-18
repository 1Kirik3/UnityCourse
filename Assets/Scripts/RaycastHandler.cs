using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Transform _spawnPoint;

    private void OnEnable()
    {
        _raycaster.OnCubeHitted += HandleRaycast;
    }

    private void Start()
    {
        _spawner.SpawnMultiple(_spawnPoint.position);
    }

    private void OnDisable()
    {
        _raycaster.OnCubeHitted -= HandleRaycast;
    }

    private void HandleRaycast(Cube cube)
    {
        if (cube.TrySplit())
        {
            var newCubes = _spawner.SpawnMultiple(cube.transform.position);

            int nextGeneration = cube.SpawnGeneration + 1;
            float nextSplitChance = cube.SplitChance / 2f;

            foreach (var newCube in newCubes)
            {
                newCube.Initilize(nextGeneration, nextSplitChance);
                _colorChanger.ChangeColor(newCube.Renderer);
                newCube.ReduceScale();
            }
        }
        else
        {
            _exploder.Explode(cube.transform.position, cube.SpawnGeneration);
        }

        Destroy(cube.gameObject);
    }

}
