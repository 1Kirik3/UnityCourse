using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 7.0f;

        [Header("Gravity Settings")]
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private float groundedGripForce = -2.0f;

        [Header("Components Settings")]
        [SerializeField] private CharacterController controller;
        [SerializeField] private InputHandler inputHandler;

        private Vector3 currentInputDirection;
        private Vector3 verticalVelocity;

        private void OnEnable()
        {
            inputHandler.OnMoveInput += HandleMoveInput;
        }

        private void OnDisable()
        {
            inputHandler.OnMoveInput -= HandleMoveInput;
        }

        private void HandleMoveInput(Vector3 direction)
        {
            currentInputDirection = direction;
        }

        private void Update()
        {
            HandleHorizontalMovement();
            HandleGravity();
        }

        private void HandleHorizontalMovement()
        {
            Vector3 moveDirection = transform.right * currentInputDirection.x + transform.forward * currentInputDirection.z;
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        private void HandleGravity()
        {
            if (controller.isGrounded && verticalVelocity.y < 0f)
            {
                verticalVelocity.y = groundedGripForce;
            }

            verticalVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }
    }
}

