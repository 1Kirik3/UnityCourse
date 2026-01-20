using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const float MinLifeTime = 2f;
    private const float MaxLifeTime = 5f;

    [SerializeField] private Renderer _renderer;

    private Color _defaultColor;
    private bool _hasCollided;

    public event Action<Cube> Expired;

    private void Awake()
    {
        _defaultColor = _renderer.material.color;
    }

    public void ResetState()
    {
        _hasCollided = false;
        _renderer.material.color = _defaultColor;
        StopAllCoroutines();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided == false && collision.gameObject.TryGetComponent(out Platfrom gameObject))
        {
            _hasCollided = true;
            _renderer.material.color = UnityEngine.Random.ColorHSV();
            StartCoroutine(WaitAndExpire());
        }
    }

    private IEnumerator WaitAndExpire()
    {
        float lifeTime = UnityEngine.Random.Range(MinLifeTime, MaxLifeTime);
        yield return new WaitForSeconds(lifeTime);

        Expired?.Invoke(this);
    }
}