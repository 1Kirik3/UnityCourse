using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _incrementStep = 1;
    [SerializeField] private float _incrementDelay = 0.5f;

    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private bool _isCounting = false;
    private int _counter = 0;

    private void Start()
    {
        UpdateTextCounter();
        StartCoroutine(IncrementCounter(_incrementDelay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();

            if (_isCounting)
            {
                StartCoroutine(IncrementCounter(_incrementDelay));
            }
            else
            {
                StopCoroutine(IncrementCounter(_incrementDelay));
            }
        }
    }

    private IEnumerator IncrementCounter(float delay)
    {
        while (_isCounting)
        {
            yield return new WaitForSeconds(delay);

            if (_isCounting)
            {
                _counter += _incrementStep;
                UpdateTextCounter();
            }
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;
    }

    private void UpdateTextCounter()
    {
        _textMeshPro.text = _counter.ToString();
    }

}
