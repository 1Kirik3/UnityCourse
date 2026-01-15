using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _incrementStep = 1;
    [SerializeField] private float _incrementDelay = 0.5f;

    [SerializeField] private InputReader _inputReader;

    public event Action<int> CounterUpdated;

    private bool _isCounting = false;
    private int _counter = 0;

    private void OnEnable()
    {
        _inputReader.MouseButtonClicked += UpdateCountingStatement;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonClicked -= UpdateCountingStatement;
    }

    private void UpdateCountingStatement()
    {
        _isCounting = !_isCounting;

        if (_isCounting )
        {
            StartCoroutine(IncrementCounter(_incrementDelay));
        }
        else
        {
            StopCoroutine(IncrementCounter(_incrementDelay));
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
                CounterUpdated?.Invoke(_counter);
            }
        }
    }

}
