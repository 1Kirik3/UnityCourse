using UnityEngine;

public class DirectionGenerator
{
    private const float MinAngle = 0f;
    private const float MaxAngle = 360f;

    public Vector3 GetRandomHorizontalDirection()
    {
        float randomAngle = Random.Range(MinAngle, MaxAngle);
        return Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
    }
}
