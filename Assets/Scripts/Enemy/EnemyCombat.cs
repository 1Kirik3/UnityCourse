using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCombat : MonoBehaviour, IDamageable, IAttacker
    {
        [SerializeField] private int _maxHealth = 2;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _cooldown = 1f;

        public bool IsDead { get; private set; }

        private float _lastAttackTime;
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(_damage);
            }
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damage);

            if (_currentHealth <= 0)
            {
                Death();
            }
        }

        public void Attack(IDamageable target)
        {
            if (target == null)
                return;

            if (Time.time >= _lastAttackTime + _cooldown)
            {
                target.TakeDamage(_damage);
                _lastAttackTime = Time.time;
            }
        }

        private void Death()
        {
            IsDead = true;
            Destroy(gameObject);
        }
    }
}
