using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int PrimaryActionKey = 0;

    public event Action<Vector2> ActionPerformed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(PrimaryActionKey))
        {
            ActionPerformed?.Invoke(Input.mousePosition);
        }
    }
}