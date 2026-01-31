using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Coin
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Coin : MonoBehaviour, ICollectable, ISpawnable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private int _value;

        private bool _isCollected = false;

        public void Collect(PlayerPocket pocket)
        {
            if (_isCollected)
                return;

            _isCollected = true;
            pocket.InreaseCoinsValue(_value);
            _animator.SetTrigger(CoinAnimatorData.CoinCollected);

        }

        public void DestroyOnCollect()
        {
            Destroy(gameObject);
        }

    }
}

