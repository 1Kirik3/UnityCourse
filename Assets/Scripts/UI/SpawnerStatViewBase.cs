using Assets.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public abstract class SpawnerStatViewBase<TSpawner> : MonoBehaviour where TSpawner : MonoBehaviour, IStatProvider
    {
        [SerializeField] private TSpawner _spawner;

        [SerializeField] protected string _label;
        [SerializeField] protected TMP_Text _displayTile;

        protected virtual IStatProvider GetSpawner() => _spawner;

        protected virtual void Start()
        {
            _spawner.OnStatsChanged += UpdateDisplay;
            UpdateDisplay();
        }

        private void OnValidate()
        {
            if (_spawner == null || _displayTile == null)
            {
                Debug.LogError("Spawner or display ate not found");
            }
        }

        private void UpdateDisplay()
        {
            _displayTile.text = $"{_label}\n" +
                                $"Spawned: {_spawner.TotalSpawned}\n" +
                                $"Created: {_spawner.TotalCreated}\n" +
                                $"Active: {_spawner.ActiveCount}";
        }

        protected virtual void OnDestroy()
        {
            _spawner.OnStatsChanged -= UpdateDisplay;
        }
    }
}