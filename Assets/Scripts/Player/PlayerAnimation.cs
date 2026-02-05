using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {   
        [SerializeField] private Animator _animator;

        public void AnimateWalking(float horizontalInput)
        {
            _animator.SetBool(PlayerAnimatorData.IsWalking, horizontalInput != 0);
        }

        public void AnimateAttack()
        {
            _animator.SetTrigger(PlayerAnimatorData.Attack);
        }

    }
}

