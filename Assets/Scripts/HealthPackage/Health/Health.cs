using System;
using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField] public float Max { get; private set; } = 100f;

        public event Action Changed;
        public float Current { get; private set; }

        private void Awake()
        {
            Current = Max;
        }

        public void TakeDamage(float amount)
        {
            if (amount < 0)
                return;

            Current = Mathf.Clamp(Current - amount, 0, Max);
            Changed?.Invoke();
        }

        public void Heal(float amount)
        {
            if (amount < 0)
                return;

            Current = Mathf.Clamp(Current + amount, 0, Max);
            Changed?.Invoke();
        }
    }
}
