using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(Renderer), typeof(Rigidbody))]
    public class Bomb : MonoBehaviour, IPoolable
    {
        private Renderer _renderer;
        private Exploder _exploder;

        public event Action<Bomb> Expired;

        public void Initialize(Exploder exploder)
        {
            _exploder = exploder;
            _exploder.OnExploded += OnExploded;
        }

        public void Activate()
        {
            _exploder.Explode(transform.position);
        }

        private void OnExploded(Exploder exploder)
        {
            Expired?.Invoke(this);
        }

        public void ResetState()
        {
            if (_exploder != null)
                _exploder.OnExploded -= OnExploded;

            StopAllCoroutines();

            if (_renderer != null)
                _renderer.material.color = Color.white;
        }

        private void OnDestroy()
        {
            if (_exploder != null)
                _exploder.OnExploded -= OnExploded;
        }
    }
}
