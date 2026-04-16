using Assets.Scripts.Bullets;
using Assets.Scripts.ScoreSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Bird
{
    [RequireComponent(typeof(BirdMover))]
    [RequireComponent(typeof(ScoreCounter))]
    [RequireComponent(typeof(BirdCollisionHandler))]
    public class Bird : MonoBehaviour
    {
        [SerializeField] private BirdMover _birdMover;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private BirdCollisionHandler _handler;

        public event Action GameOver;

        private void OnEnable()
        {
            _handler.CollisionDetected += ProcessCollision;
        }

        private void OnDisable()
        {
            _handler.CollisionDetected -= ProcessCollision;
        }

        public void Reset()
        {
            _scoreCounter.Reset();
            _birdMover.Reset();
        }

        public void Die()
        {
            GameOver?.Invoke();
        }

        private void ProcessCollision(IInteractable interactable)
        {
            if (interactable is Enemy.Enemy || interactable is Bullet bullet && !bullet.GetComponent<Bullet>())
            {
                GameOver?.Invoke();
            }
        }

    }
}

