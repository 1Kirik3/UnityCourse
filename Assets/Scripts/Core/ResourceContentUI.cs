using TMPro;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ResourceCounterUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Base _targetBase;
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private string _prefix = "Resources: ";

        private void OnEnable()
        {
            if (_targetBase != null)
            {
                _targetBase.OnResourcesChanged += UpdateResourceText;
            }
        }

        private void OnDisable()
        {
            if (_targetBase != null)
            {
                _targetBase.OnResourcesChanged -= UpdateResourceText;
            }
        }

        private void UpdateResourceText(int currentResources)
        {
            if (_counterText != null)
            {
                _counterText.text = $"{_prefix}{currentResources}";
            }
        }
    }
}
