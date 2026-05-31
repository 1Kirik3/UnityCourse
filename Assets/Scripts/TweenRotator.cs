using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    public class TweenRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationTarget = new Vector3(0, 360, 0);
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
            transform.DORotate(_rotationTarget, _duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(_easeType);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
