using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public event Action<Vector3> OnMoveInput;

        private void Update()
        {
            float inputX = Input.GetAxisRaw(HorizontalAxis);
            float inputZ = Input.GetAxisRaw(VerticalAxis);

            Vector3 inputDirection = new Vector3(inputX, 0f, inputZ);

            if (inputDirection.sqrMagnitude > 1.0f)
            {
                inputDirection.Normalize();
            }

            OnMoveInput?.Invoke(inputDirection);
        }
    }
}

