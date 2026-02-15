using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 100f;

    private float _current;

    public event Action Changed;

    public float Current => _current;
    public float Max => _max;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0) 
            return;

        _current = Mathf.Clamp(_current - amount, 0, _max);
        Changed?.Invoke();
    }

    public void Heal(float amount)
    {
        if (amount < 0) 
            return;

        _current = Mathf.Clamp(_current + amount, 0, _max);
        Changed?.Invoke();
    }
}