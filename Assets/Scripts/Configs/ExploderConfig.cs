using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ExploderConfig", menuName = "Configs/ExploderConfig")]
    public class ExploderConfig : ScriptableObject
    {
        [Header("Explosion Settings")]
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private float _explosionForce = 700f;
        [SerializeField] private float _minDetonationTime = 2f;
        [SerializeField] private float _maxDetonationTime = 5f;

        public float ExplosionRadius => _explosionRadius;
        public float ExplosionForce => _explosionForce;
        public float MinDetonationTime => _minDetonationTime;
        public float MaxDetonationTime => _maxDetonationTime;
    }
}
