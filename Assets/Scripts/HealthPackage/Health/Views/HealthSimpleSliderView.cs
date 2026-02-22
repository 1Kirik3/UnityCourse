using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.HealthPackage.Health.Views
{
    public class HealthSimpleSliderView : HealthView
    {
        [SerializeField] protected Slider Slider;

        protected override void OnStateChanged()
        {
            Slider.value = Health.Current / Health.Max;
        }

    }

}
