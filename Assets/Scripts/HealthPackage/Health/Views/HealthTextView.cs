using TMPro;
using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health.Views
{
    public class HealthTextView : HealthView
    {
        [SerializeField] private TMP_Text _text;

        protected override void OnStateChanged()
        {
            _text.text = $"{Health.Current} / {Health.Max}";
        }
    }
}
