using Assets.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class SpawnerStatPresenter : MonoBehaviour
    {
        [SerializeField] private string _label;
        [SerializeField] private TMP_Text _displayTile;
        [SerializeField] private GameObject _spawnerObject;

        private IStatProvider _provider;

        private void Start()
        {
            _provider = _spawnerObject.GetComponent<IStatProvider>();
        }

        private void Update()
        {
            if (_provider == null) return;

            _displayTile.text = $"{_label}\n" +
                                $"Spawned: {_provider.TotalSpawned}\n" +
                                $"Created: {_provider.TotalCreated}\n" +
                                $"Active: {_provider.ActiveCount}";
        }
    }

}
