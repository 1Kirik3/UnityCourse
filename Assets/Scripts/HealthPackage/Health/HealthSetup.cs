using Assets.Scripts.HealthPackage.Buttons;
using Assets.Scripts.HealthPackage.Health.Views;
using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health
{
    public class HealthSetup : MonoBehaviour
    {
        [SerializeField] private Health _playerHealth;

        [SerializeField] private HealthTextView _textView;
        [SerializeField] private HealthSimpleSliderView _simpleSliderView;
        [SerializeField] private HealthSmoothSliderView _smoothSliderView;

        [SerializeField] private DamageButtonView _damageButton;
        [SerializeField] private HealButtonView _healButton;

        private void Start()
        {
            _textView.Initialize(_playerHealth);
            _simpleSliderView.Initialize(_playerHealth);
            _smoothSliderView.Initialize(_playerHealth);

            _damageButton.Initialize(_playerHealth);
            _healButton.Initialize(_playerHealth);
        }
    }
}
