using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Target _target;

    public void Initialize(Target target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null) return;

        Vector3 direction = (_target.transform.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        transform.LookAt(_target.transform.position);
    }
}
