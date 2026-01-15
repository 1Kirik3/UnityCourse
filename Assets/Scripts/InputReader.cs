using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonClicked?.Invoke();
        }
    }

}
