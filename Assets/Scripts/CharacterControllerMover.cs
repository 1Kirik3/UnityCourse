using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerMover : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _moveSpeed = 7.0f;

        [Header("Gravity Settings")]
        [SerializeField] private float _gravityValue = -9.81f;
        [SerializeField] private float _groundedGripForce = -2.0f;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private InputHandler _inputHandler;

        private Vector3 _currentInputDirection;
        private Vector3 _verticalVelocity;

        private void OnEnable()
        {
            _inputHandler.MoveInputReceived += SetInputDirection;
        }

        private void OnDisable()
        {
            _inputHandler.MoveInputReceived -= SetInputDirection;
        }

        private void Update()
        {
            ApplyHorizontalMovement();
            ApplyGravity();
        }

        private void SetInputDirection(Vector3 inputDirection)
        {
            _currentInputDirection = inputDirection;
        }

        private void ApplyHorizontalMovement()
        {
            Vector3 moveDirection = transform.right * _currentInputDirection.x + transform.forward * _currentInputDirection.z;
            _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
        }

        private void ApplyGravity()
        {
            if (_characterController.isGrounded && _verticalVelocity.y < 0f)
            {
                _verticalVelocity.y = _groundedGripForce;
            }

            _verticalVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_verticalVelocity * Time.deltaTime);
        }
    }
}

