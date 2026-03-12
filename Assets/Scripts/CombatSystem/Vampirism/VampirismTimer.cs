using Assets.Scripts.Services;
using System;
using UnityEngine;

namespace Assets.Scripts.CombatSystem.Vampirism
{
    public class VampirismTimer : MonoBehaviour
    {
        public event Action Updated;

        [SerializeField] private InputReader _input;
        [SerializeField] private float _activeDuration = 6f;
        [SerializeField] private float _cooldownDuration = 4f;

        private float _timer;

        public bool IsActive { get; private set; }
        public bool IsOnCooldown { get; private set; }
        public float Progress { get; private set; }

        private void OnEnable() => _input.VampirismPressed += TryActivate;
        private void OnDisable() => _input.VampirismPressed -= TryActivate;

        private void Update()
        {
            if (IsActive)
            {
                _timer -= Time.deltaTime;
                Progress = Mathf.Clamp01(_timer / _activeDuration);
                Updated?.Invoke();

                if (_timer <= 0)
                    StartCooldown();
            }
            else if (IsOnCooldown)
            {
                _timer += Time.deltaTime;
                Progress = Mathf.Clamp01(_timer / _cooldownDuration);
                Updated?.Invoke();

                if (_timer >= _cooldownDuration)
                    IsOnCooldown = false;
            }
        }

        private void TryActivate()
        {
            if (IsActive == false && IsOnCooldown == false)
            {
                IsActive = true;
                _timer = _activeDuration;
            }
        }

        private void StartCooldown()
        {
            IsActive = false;
            IsOnCooldown = true;
            _timer = 0;
        }
    }
}

