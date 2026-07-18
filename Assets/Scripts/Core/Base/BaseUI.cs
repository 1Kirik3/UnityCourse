using TMPro;
using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class BaseUI : MonoBehaviour
    {
        [SerializeField] private BaseStorage _storage;
        [SerializeField] private TextMeshProUGUI _resourcesText;

        private void OnEnable()
        {
            _storage.ResourcesChanged += UpdateUI;

            UpdateUI(_storage.CurrentAmount);
        }

        private void OnDisable()
        {
            _storage.ResourcesChanged -= UpdateUI;
        }

        private void UpdateUI(int amount)
        {
            if (_resourcesText != null)
            {
                _resourcesText.text = $"Ресурсы: {amount}";
            }
        }
    }
}
