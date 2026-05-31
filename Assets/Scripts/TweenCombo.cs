using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(TweenMover))]
    [RequireComponent(typeof(TweenRotator))]
    [RequireComponent(typeof(TweenScaler))]
    public class TweenCombo : MonoBehaviour
    {
        [SerializeField] private TweenMover _mover;
        [SerializeField] private TweenRotator _rotator;
        [SerializeField] private TweenScaler _scaler;

        private void Start()
        {
            _mover.Play();
            _rotator.Play();
            _scaler.Play();
        }
    }
}
