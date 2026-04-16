using System;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class InputHandler : MonoBehaviour
    {
        private const KeyCode JumpCode = KeyCode.Space;
        private const KeyCode ShootCode = KeyCode.E;

        public event Action JumpPressed;
        public event Action ShootPressed;

        private void Update()
        {
            if (Input.GetKeyDown(JumpCode))
            {
                JumpPressed?.Invoke();
            }

            if (Input.GetKeyDown(ShootCode))
            {
                ShootPressed?.Invoke();
            }
        }
    }
}
