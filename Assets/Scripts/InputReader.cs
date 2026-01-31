using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    public event Action<float> OnHorizontalMovement;
    public event Action OnJumpPressed;

    private void Update()
    {
        HandleHorizontalInput();
        HandleJump();
    }

    private void HandleHorizontalInput()
    {
        float inputValue = Input.GetAxisRaw(HorizontalAxis);
        OnHorizontalMovement?.Invoke(inputValue);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnJumpPressed?.Invoke();

    }

}
