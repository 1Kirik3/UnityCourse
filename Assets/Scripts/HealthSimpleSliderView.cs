using UnityEngine;
using UnityEngine.UI;

public class HealthSimpleSliderView : HealthView
{
    [SerializeField] protected Slider _slider;

    protected override void OnStateChanged()
    {
        _slider.value = _health.Current / _health.Max;
    }

}
