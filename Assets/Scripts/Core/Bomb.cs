using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(Renderer), typeof(Rigidbody))]
    public class Bomb : MonoBehaviour, IPoolable
    {
        private Exploder _exploder;

        public event Action<Bomb> Expired;

        [field: SerializeField] public Renderer Renderer {  get; private set; }

        public void Initialize(Exploder exploder)
        {
            _exploder = exploder;
        }

        public void Activate()
        {
            _exploder.OnExploded += OnExploded;
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

            if (Renderer != null)
                Renderer.material.color = Color.white;
        }

        private void OnDestroy()
        {
            if (_exploder != null)
                _exploder.OnExploded -= OnExploded;
        }
    }
}
