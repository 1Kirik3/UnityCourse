using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCombat : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _cooldown = 3f;

        private float _lastAttackTime;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                Attack(target);
            }
        }

        private void Attack(IDamageable target)
        {
            if (target == null)
                return;

            if (Time.time >= _lastAttackTime + _cooldown)
            {
                target.TakeDamage(_damage);
                _lastAttackTime = Time.time;
            }
        }

    }
}
