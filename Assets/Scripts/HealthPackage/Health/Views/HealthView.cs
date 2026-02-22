using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health.Views
{
    public abstract class HealthView : MonoBehaviour
    {
        [SerializeField] protected Health Health;

        public virtual void Initialize()
        {
            Health.Changed += OnStateChanged;
            OnStateChanged();
        }

        protected virtual void OnDisable()
        {
            if (Health != null)
                Health.Changed -= OnStateChanged;
        }

        protected abstract void OnStateChanged();
    }
}


