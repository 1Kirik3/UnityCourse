using UnityEngine;

namespace Assets.Scripts.Player
{
    public static class PlayerAnimatorData
    {
        public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    }
}

