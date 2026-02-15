using UnityEngine;
using UnityEngine.UI;

public class HealthSimpleSliderView : HealthView
{
    [SerializeField] private Slider _slider;

    protected override void OnStateChanged()
    {
        _slider.value = ViewModel.NormalizedValue;
    }

}
