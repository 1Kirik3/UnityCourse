using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Transform _initialSpawnPoint;

    private void OnEnable()
    {
        _raycaster.OnCubeHitted += HandleCubeClick;
    }

    private void Start()
    {
        _spawner.CreateInitialCubes(_initialSpawnPoint.position);
    }

    private void OnDisable()
    {
        _raycaster.OnCubeHitted -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        if (cube.CanSplit())
        {
            var newCubes = _spawner.SpawnSplittedCubes(cube);
            _exploder.ExplodeNewCubes(newCubes, cube.transform.position);
        }
        else
        {
            _exploder.ExplodeEverything(cube.transform.position, cube.SpawnGeneration);
        }

        _spawner.DestroyCube(cube);
    }
}