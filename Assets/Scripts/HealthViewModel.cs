using System;

public class HealthViewModel
{
    private readonly Health _health;

    public event Action StateChanged;

    public float Current => _health.Current;
    public float Max => _health.Max;
    public float NormalizedValue => _health.Current / _health.Max;

    public HealthViewModel(Health health)
    {
        _health = health;
        _health.Changed += OnModelChanged;
    }

    private void OnModelChanged() => StateChanged?.Invoke();
    public void ApplyDamage(float damage) => _health.TakeDamage(damage);
    public void ApplyHeal(float amount) => _health.Heal(amount);
}
