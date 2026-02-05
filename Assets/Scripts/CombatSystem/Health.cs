using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] protected int _maxHealth = 3;

        public bool IsDead { get; private set; }

        protected int _currentHealth;

        public void Heal(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damage);

            if (_currentHealth <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            IsDead = true;
            Destroy(gameObject);
        }

    }
}

