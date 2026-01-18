using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Raycaster _raycaster;
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
        var splitChance = 1f;
        var spawnGeneration = 1;

        var isSplitted = cube.TrySplit(out spawnGeneration, out splitChance);

        if (isSplitted)
        {
            var newCubes = _spawner.SpawnMultiple(cube.transform.position);
            splitChance /= 2f;
            spawnGeneration++;

            foreach (var newCube in newCubes)
            {
                newCube.Initilize(spawnGeneration, splitChance);
                _colorChanger.ChangeColor(newCube.Renderer);
                newCube.ReduceScale();
            }
        }

        cube.Explode();
    }
}
