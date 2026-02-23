using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.HealthPackage.Health
{
    public class Health : MonoBehaviour, IDamageable
    {
        public event Action Changed;
        [field: SerializeField] public float Max { get; private set; } = 3f;
        public float Current { get; private set; }
        public bool IsDead { get; private set; }


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

            if (Current <= 0)
                Death();
        }

        public void Heal(float amount)
        {
            if (amount < 0)
                return;

            Current = Mathf.Clamp(Current + amount, 0, Max);
            Changed?.Invoke();
        }

        private void Death()
        {
            IsDead = true;
            Destroy(gameObject);
        }

    }
}
