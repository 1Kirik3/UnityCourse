using UnityEngine;

namespace Assets.Scripts.Coin
{
    public static class CoinAnimatorData
    {
        public static readonly int CoinCollected = Animator.StringToHash(nameof(CoinCollected));
    }
}
