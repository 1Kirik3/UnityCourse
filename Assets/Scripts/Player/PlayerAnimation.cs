using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private const int RightRotationY = 180;
        private const int LeftRotationY = 0;
        
        [SerializeField] private Animator _animator;

        public void AnimateWalking(float horizontalInput)
        {
            _animator.SetBool(PlayerAnimatorData.IsWalking, horizontalInput != 0);
        }

        public void RotatePlayer(Transform playerTransform, float movementDirection)
        {
            if (movementDirection > 0)
            {
                playerTransform.rotation = Quaternion.Euler(0, RightRotationY, 0);
            }
            else if (movementDirection < 0)
            {
                playerTransform.rotation = Quaternion.Euler(0, LeftRotationY, 0);
            }
        }
    }
}

