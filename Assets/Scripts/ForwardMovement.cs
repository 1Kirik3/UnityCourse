using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        transform.position += _transform.forward * _movementSpeed * Time.deltaTime;
    }
}
