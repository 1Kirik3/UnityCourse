using Assets.Scripts.Bullets;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour, IInteractable
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
                _shooter.enabled = true;
        }

        public void Die()
        {
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bird.Bird bird))
            {
                bird.Die();
            }
        }
    }
}

