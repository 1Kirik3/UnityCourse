using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TweenTextEffect : MonoBehaviour
    {
        [SerializeField] private float _effectDuration = 1.5f;
        [SerializeField] private TextMeshProUGUI _textComponent;
        private Sequence _textSequence;

        private void Start()
        {
            AnimateText();
        }

        private void AnimateText()
        {
            _textSequence = DOTween.Sequence();

            _textSequence.Append(CreateTextTween("New text", _effectDuration));
            _textSequence.AppendInterval(0.5f);

            _textSequence.Append(CreateTextTween("New text + extra", _effectDuration));
            _textSequence.AppendInterval(0.5f);

            _textSequence.Append(CreateTextTween("matrix", _effectDuration, ScrambleMode.All));
            _textSequence.AppendInterval(1f);

            _textSequence.Append(CreateTextTween("start", _effectDuration));

            _textSequence.SetLoops(-1, LoopType.Restart);
        }

        private Tweener CreateTextTween(string endValue, float duration, ScrambleMode scrambleMode = ScrambleMode.None)
        {
            return DOTween.To(() => _textComponent.text, x => _textComponent.text = x, endValue, duration)
                .SetOptions(true, scrambleMode)
                .SetTarget(_textComponent);
        }

        private void OnDestroy()
        {
            _textSequence?.Kill();
        }
    }
}

