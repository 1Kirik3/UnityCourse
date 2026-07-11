using TMPro;
using UnityEngine;

namespace Assets.Scripts.Core.ResourcesLogic
{
    public class ResourceCounterDisplay : MonoBehaviour
    {
        [SerializeField] private Base.BaseStorage _targetStorage;
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private string _prefixText = "Resources: ";

        private void OnEnable()
        {
            if (_targetStorage != null)
            {
                _targetStorage.ResourcesChanged += OnResourcesChanged;
            }
        }

        private void OnDisable()
        {
            if (_targetStorage != null)
            {
                _targetStorage.ResourcesChanged -= OnResourcesChanged;
            }
        }

        private void OnResourcesChanged(int currentResources)
        {
            if (_counterText != null)
            {
                _counterText.text = $"{_prefixText}{currentResources}";
            }
        }
    }
}
