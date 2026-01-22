using System.Collections;
using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _waitDuration = 1f;

    private Vector3 _flipRotation = new Vector3 (0, 180, 0);
    private float _directionX = 1f;

    private void Update()
    {
        Move();
    }

    public void StartExitRoutine()
    {
        StartCoroutine(WaitAndFlip());
    }

    private void Move()
    {
        transform.Translate(Vector2.right * _directionX * _speed * Time.deltaTime);
    }

    private IEnumerator WaitAndFlip()
    {
        yield return new WaitForSeconds(_waitDuration);

        transform.Rotate(_flipRotation, Space.World);
    }
}
