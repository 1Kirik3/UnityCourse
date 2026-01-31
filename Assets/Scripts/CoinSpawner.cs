using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;       // Префаб твоей монетки
    [SerializeField] private List<Transform> _spawnPoints; // Точки, которые ты расставил

    private void Start()
    {
        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        if (_coinPrefab == null || _spawnPoints.Count == 0) return;

        foreach (Transform point in _spawnPoints)
        {
            Instantiate(_coinPrefab, point.position, Quaternion.identity, transform);
        }
    }

}
