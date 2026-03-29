using Assets.Scripts.Configs;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Exploder : IExploder
    {
        private readonly ExploderConfig _config;
        private readonly MonoBehaviour _coroutineHost;
        private readonly Renderer _renderer;

        public event Action<Exploder> OnExploded;

        public Exploder(ExploderConfig config, MonoBehaviour coroutineHost, Renderer renderer)
        {
            _config = config;
            _coroutineHost = coroutineHost;
            _renderer = renderer;
        }

        public void Explode(Vector3 position)
        {
            _coroutineHost.StartCoroutine(FadeAndExplode(position));
        }

        private IEnumerator FadeAndExplode(Vector3 position)
        {
            float duration = UnityEngine.Random.Range(_config.MinDetonationTime, _config.MaxDetonationTime);
            float elapsed = 0;
            Color color = Color.black;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                color.a = Mathf.Lerp(1f, 0f, elapsed / duration);
                _renderer.material.color = color;
                yield return null;
            }

            ApplyExplosionForce(position);
            OnExploded?.Invoke(this);
        }

        private void ApplyExplosionForce(Vector3 position)
        {
            Collider[] targets = Physics.OverlapSphere(position, _config.ExplosionRadius);

            foreach (var target in targets)
            {
                if (target.TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(_config.ExplosionForce, position, _config.ExplosionRadius);
            }
        }
    }
}
