using Assets.Scripts.CombatSystem;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.FirstAidKid
{
    public class FirstAidKid : MonoBehaviour, ICollectable, ISpawnable
    {
        [SerializeField] private int _healAmount = 1;

        public void Collect(PlayerCollector collector)
        {
            if (collector.TryGetComponent(out Health health))
            {
                health.Heal(_healAmount);
                Destroy(gameObject);
            }
        }
    }
}

