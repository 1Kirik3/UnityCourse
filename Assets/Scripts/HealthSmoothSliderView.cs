using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSliderView : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed = 2f;

    private float _targetValue;

    protected override void OnStateChanged()
    {
        _targetValue = ViewModel.NormalizedValue;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
    }
}