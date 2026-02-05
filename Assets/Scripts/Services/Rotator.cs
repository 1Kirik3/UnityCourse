using UnityEngine;

public static class Rotator
{
    private const int RightRotationY = 180;
    private const int LeftRotationY = 0;

    public static void RotatePlayer(Transform playerTransform, float movementDirection)
    {
        if (movementDirection > 0)
        {
            playerTransform.rotation = Quaternion.Euler(0, RightRotationY, 0);
        }
        else if (movementDirection < 0)
        {
            playerTransform.rotation = Quaternion.Euler(0, LeftRotationY, 0);
        }
    }
}
