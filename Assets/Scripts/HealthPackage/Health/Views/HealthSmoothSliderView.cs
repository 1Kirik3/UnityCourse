using System.Collections;
using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health.Views
{
    public class HealthSmoothSliderView : HealthSimpleSliderView
    {
        [SerializeField] private float _duration = 0.5f;
        private Coroutine _updateCoroutine;

        protected override void OnStateChanged()
        {
            if (_updateCoroutine != null)
                StopCoroutine(_updateCoroutine);

            _updateCoroutine = StartCoroutine(AnimateSlider(_health.Current / _health.Max));
        }

        private IEnumerator AnimateSlider(float targetValue)
        {
            float startValue = Slider.value;
            float elapsed = 0f;

            while (elapsed < _duration)
            {
                elapsed += Time.deltaTime;
                Slider.value = Mathf.Lerp(startValue, targetValue, elapsed / _duration);
                yield return null;
            }

            Slider.value = targetValue;
        }
    }
}
