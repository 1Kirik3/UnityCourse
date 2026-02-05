using System;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class InputReader : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const KeyCode JumpKey = KeyCode.Space;
        private const KeyCode AttackKey = KeyCode.F;

        public event Action<float> HorizontalMovementPressed;
        public event Action JumpPressed;
        public event Action AttackPressed;

        private void Update()
        {
            HandleHorizontalInput();
            HandleJump();
            HandleAttack();
        }

        private void HandleHorizontalInput()
        {
            float inputValue = Input.GetAxisRaw(HorizontalAxis);
            HorizontalMovementPressed?.Invoke(inputValue);
        }

        private void HandleJump()
        {
            if (Input.GetKeyDown(JumpKey))
                JumpPressed?.Invoke();
        }

        private void HandleAttack()
        {
            if (Input.GetKeyDown(AttackKey))
                AttackPressed?.Invoke();
        }

    }
}

