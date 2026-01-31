using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.FirstAidKid
{
    public class FirstAidKid : MonoBehaviour, ICollectable, ISpawnable
    {
        [SerializeField] private int _healAmount = 1;

        public void Collect(PlayerPocket pocket)
        {
            if (pocket.TryGetComponent(out PlayerCombat playerCombat))
            {
                playerCombat.Heal(_healAmount);
                Destroy(gameObject);
            }
        }
    }
}

