using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        _transform.Rotate(0, _rotationSpeed, 0);
    }
}
