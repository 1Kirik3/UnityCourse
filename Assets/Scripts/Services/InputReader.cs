using System;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class InputReader : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const KeyCode JumpKey = KeyCode.Space;
        private const KeyCode AttackKey = KeyCode.F;
        private const KeyCode VampirismKey = KeyCode.E;

        public event Action<float> HorizontalMovementPressed;
        public event Action JumpPressed;
        public event Action AttackPressed;
        public event Action VampirismPressed;

        private void Update()
        {
            HandleHorizontalInput();
            HandleJump();
            HandleAttack();
            HandleVampirism();
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

        private void HandleVampirism()
        {
            if (Input.GetKeyDown(VampirismKey))
                VampirismPressed?.Invoke();
        }

    }
}

