using UnityEngine.Pool;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 20;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => cube.gameObject.SetActive(true),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
        );
    }

    public Cube Get()
    {
        Cube cube = _pool.Get();
        cube.ResetState();
        cube.Expired += Release;
        return cube;
    }

    private void Release(Cube cube)
    {
        cube.Expired -= Release;
        _pool.Release(cube);
    }
}