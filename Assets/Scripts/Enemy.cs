using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _moveDirection;

    public void Initialize(Vector3 direction)
    {
        _moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime, Space.World);
    }
}
