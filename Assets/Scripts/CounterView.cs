using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterUpdated += UpdateTextCounter;
    }

    private void OnDisable()
    {
        _counter.CounterUpdated -= UpdateTextCounter;
    }

    private void UpdateTextCounter(int counterValue)
    {
        _textMeshPro.text = counterValue.ToString();
    }

}
