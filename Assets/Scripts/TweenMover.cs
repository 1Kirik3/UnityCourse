using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class TweenMover : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private Ease _easeType = Ease.Linear;
        [SerializeField] private bool _playOnStart = true;

        private void Start()
        {
            if (_playOnStart)
            {
                Play();
            }
        }

        public void Play()
        {
            transform.DOMove(_targetPosition, _duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(_easeType);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
