using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class LifeCycleManager : MonoBehaviour
    {
        [Header("Spawners")]
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private BombSpawner _bombSpawner;

        [Header("Spawn Settings")]
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
                SpawnCube();
                yield return wait;
            }
        }

        private void SpawnCube()
        {
            Cube cube = _cubeSpawner.Get();
            cube.ResetState();
            cube.transform.position = GetRandomPoint();

            if (cube.TryGetComponent(out Rigidbody rb))
                rb.velocity = rb.angularVelocity = Vector3.zero;

            cube.Expired += OnCubeExpired;
        }

        private void OnCubeExpired(Cube cube)
        {
            cube.Expired -= OnCubeExpired;
            Vector3 pos = cube.transform.position;
            _cubeSpawner.Release(cube);

            Bomb bomb = _bombSpawner.Get();
            bomb.transform.position = pos;
            bomb.Activate();
            bomb.Expired += OnBombExpired;
        }

        private void OnBombExpired(Bomb bomb)
        {
            bomb.Expired -= OnBombExpired;
            _bombSpawner.Release(bomb);
        }

        private Vector3 GetRandomPoint()
        {
            Vector3 offset = new Vector3(UnityEngine.Random.Range(-_spawnRadius, _spawnRadius), 0, UnityEngine.Random.Range(-_spawnRadius, _spawnRadius));
            return _spawnArea.position + offset;
        }
    }
}
