using Assets.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public abstract class SpawnerStatViewBase : MonoBehaviour
    {
        [SerializeField] protected string _label;
        [SerializeField] protected TMP_Text _displayTile;

        protected abstract IStatProvider GetSpawner();

        protected virtual void Start()
        {
            var spawner = GetSpawner();
            if (spawner != null)
                spawner.OnStatsChanged += UpdateDisplay;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            var spawner = GetSpawner();
            if (_displayTile == null || spawner == null) return;

            _displayTile.text = $"{_label}\n" +
                                $"Spawned: {spawner.TotalSpawned}\n" +
                                $"Created: {spawner.TotalCreated}\n" +
                                $"Active: {spawner.ActiveCount}";
        }

        protected virtual void OnDestroy()
        {
            var spawner = GetSpawner();
            if (spawner != null)
                spawner.OnStatsChanged -= UpdateDisplay;
        }
    }
}