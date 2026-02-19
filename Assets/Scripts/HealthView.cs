using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    protected Health _health;

    public virtual void Initialize(Health health)
    {
        _health = health;
        _health.Changed += OnStateChanged;
        OnStateChanged();
    }

    protected virtual void OnDisable()
    {
        if (_health != null)
            _health.Changed -= OnStateChanged;
    }

    protected abstract void OnStateChanged();
}
