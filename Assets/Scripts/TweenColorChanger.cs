using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]
    public class TweenColorChanger : MonoBehaviour
    {
        [SerializeField] private Color _targetColor = Color.red;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private Ease _easeType = Ease.Linear;

        private Material _material;

        private void Start()
        {
            _material = GetComponent<Renderer>().material;

            _material.DOColor(_targetColor, _duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(_easeType);
        }

        private void OnDestroy()
        {
            if (_material != null)
            {
                _material.DOKill();
                Destroy(_material);
            }
        }
    }
}

