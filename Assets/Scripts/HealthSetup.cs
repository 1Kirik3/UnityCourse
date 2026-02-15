using UnityEngine;

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
        var viewModel = new HealthViewModel(_playerHealth);

        _textView.Initialize(viewModel);
        _simpleSliderView.Initialize(viewModel);
        _smoothSliderView.Initialize(viewModel);

        _damageButton.Initialize(viewModel);
        _healButton.Initialize(viewModel);
    }
}