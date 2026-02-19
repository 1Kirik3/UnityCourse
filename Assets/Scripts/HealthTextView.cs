using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [SerializeField] private TMP_Text _text;

    protected override void OnStateChanged()
    {
        _text.text = $"{_health.Current} / {_health.Max}";
    }
}