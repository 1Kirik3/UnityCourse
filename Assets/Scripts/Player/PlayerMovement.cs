using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private CapsuleCollider2D _collider;
        [SerializeField] private GroundChecker _groundChecker;

        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _jumpForce = 7.0f;

        private bool _isJumping = false;
        private float _horizontalInput;

        private void OnEnable()
        {
            _inputReader.OnHorizontalMovement += HandleHorizontalMovement;
            _inputReader.OnJumpPressed += HandleJumpPressed;
        }

        private void OnDisable()
        {
            _inputReader.OnHorizontalMovement -= HandleHorizontalMovement;
            _inputReader.OnJumpPressed -= HandleJumpPressed;
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleJump();
        }

        private void HandleHorizontalMovement(float input)
        {
            _horizontalInput = input;
        }

        private void HandleMovement()
        {
            float targetVelocityX = _horizontalInput * _movementSpeed;
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = Mathf.Lerp(velocity.x, targetVelocityX, Time.fixedDeltaTime * 10f);
            _rigidbody.velocity = velocity;

            _playerAnimation.RotatePlayer(transform, _horizontalInput);
            _playerAnimation.AnimateWalking(_horizontalInput);
        }

        private void HandleJumpPressed()
        {
            if (_groundChecker.IsGrounded)
            {
                _isJumping = true;
            }
        }

        private void HandleJump()
        {
            if (_isJumping)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                _isJumping = false;
            }
        }

    }
}

