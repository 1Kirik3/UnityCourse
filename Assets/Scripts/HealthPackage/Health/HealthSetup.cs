using Assets.Scripts.HealthPackage.Health.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health
{
    public class HealthSetup : MonoBehaviour
    {
        [SerializeField] private List<HealthSmoothSliderView> _smoothSliderView;

        private void Start()
        {
            foreach (var sliderView in _smoothSliderView)
            {
                sliderView.Initialize();
            }       
        }
    }
}
