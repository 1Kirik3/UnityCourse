using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class TweenScaler : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetScale = new Vector3(1.5f, 1.5f, 1.5f);
        [SerializeField] private float _duration = 1.5f;
        [SerializeField] private Ease _easeType = Ease.InOutQuad;
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
            transform.DOScale(_targetScale, _duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(_easeType);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
