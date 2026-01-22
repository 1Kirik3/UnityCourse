using System.Collections;
using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _waitDuration = 1f;

    private float _directionX = 1f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * _directionX * _speed * Time.deltaTime);
    }

    public void StartExitRoutine()
    {
        StartCoroutine(WaitAndFlip());
    }

    private IEnumerator WaitAndFlip()
    {
        yield return new WaitForSeconds(_waitDuration);

        _directionX *= -1;

        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;

    }
}
