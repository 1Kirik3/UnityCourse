using Assets.Scripts.Bullets;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour, IInteractable, IDamageable
    {
        public event Action<Enemy> Died;
        private EnemyShooter _shooter;

        private void Awake()
        {
            _shooter = GetComponent<EnemyShooter>();
        }

        public void Init(BulletPool bulletPool)
        {
            if (_shooter != null)
                _shooter.Init(bulletPool);
        }

        public void Activate()
        {
            gameObject.SetActive(true);

            if (_shooter != null)
                _shooter.StartShooting();
        }

        public void Deactivate()
        {
            if (_shooter != null)
                _shooter.StopShooting();

            gameObject.SetActive(false);
        }

        public void TakeDamage()
        {
            Die();
        }

        public void Die()
        {
            Died?.Invoke(this);
            Deactivate();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bird.Bird bird))
            {
                bird.TakeDamage();
            }
        }
    }
}