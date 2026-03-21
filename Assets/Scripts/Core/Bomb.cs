using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(Renderer), typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        [Header("Explosion Settings")]
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private float _explosionForce = 700f;
        [SerializeField] private float _minDetonationTime = 2f;
        [SerializeField] private float _maxDetonationTime = 5f;

        private Renderer _renderer;
        public event Action<Bomb> Expired;

        private void Awake() => _renderer = GetComponent<Renderer>();

        public void Activate() => StartCoroutine(FadeAndExplode());

        private IEnumerator FadeAndExplode()
        {
            float duration = UnityEngine.Random.Range(_minDetonationTime, _maxDetonationTime);
            float elapsed = 0;
            Color color = Color.black;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                color.a = Mathf.Lerp(1f, 0f, elapsed / duration);
                _renderer.material.color = color;
                yield return null;
            }

            Explode();
            Expired?.Invoke(this);
        }

        private void Explode()
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, _explosionRadius);

            foreach (var target in targets)
            {
                if (target.TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
