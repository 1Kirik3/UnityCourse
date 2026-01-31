using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string WalkingCondition = "IsWalking";

    [SerializeField] private Animator _animator;

    public void AnimateWalking(float horizontalInput)
    {
        if (horizontalInput != 0)
            _animator.SetBool(WalkingCondition, true);
        else
            _animator.SetBool(WalkingCondition, false);
    }

    public void FlipSprite(SpriteRenderer renderer, float movementDirection)
    {
        renderer.flipX = movementDirection == 0 ? renderer.flipX : movementDirection > 0;
    }

}
