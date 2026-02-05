using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                Debug.Log("Deal damage");
                target.TakeDamage(_damage);
            }
        }

    }
}

