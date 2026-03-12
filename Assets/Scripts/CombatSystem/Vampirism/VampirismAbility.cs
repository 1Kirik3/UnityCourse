using Assets.Scripts.HealthPackage.Health;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.CombatSystem.Vampirism
{
    public class VampirismAbility : MonoBehaviour
    {
        [SerializeField] private VampirismTimer _timer;
        [SerializeField] private VampirismArea _vampirismArea;
        [SerializeField] private Health _playerHealth;
        [SerializeField] private float _damagePerSecond = 1f;

        private void Update()
        {
            if (_timer.IsActive)
                ApplyEffect();
        }

        private void ApplyEffect()
        {
            IDamageable target = _vampirismArea.GetClosestTarget(transform.position);

            if (target != null)
            {
                float value = _damagePerSecond * Time.deltaTime;

                var obj = (Health)target;
                target.TakeDamage(value);
                _playerHealth.Heal(value);
            }
        }
    }
}

