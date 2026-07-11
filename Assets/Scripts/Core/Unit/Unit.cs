using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Unit
{
    [RequireComponent(typeof(UnitMover))]
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Transform _carryPoint;
        [SerializeField] private float _interactionDistance = 1.5f;

        public event Action<Unit> ResourceDelivered;

        private UnitMover _mover;
        private IResource _targetResource;
        private Transform _dropOffPoint;

        private enum UnitState { Idle, MovingToResource, ReturningToDropOff }
        private UnitState _currentState = UnitState.Idle;

        public bool IsFree => _currentState == UnitState.Idle;

        private void Awake()
        {
            _mover = GetComponent<UnitMover>();
        }

        private void Update()
        {
            if (_currentState == UnitState.MovingToResource)
            {
                HandleMovingToResource();
            }
            else if (_currentState == UnitState.ReturningToDropOff)
            {
                HandleReturningToDropOff();
            }
        }

        public void AssignTask(IResource resource, Transform dropOffPoint)
        {
            _targetResource = resource;
            _dropOffPoint = dropOffPoint;

            _currentState = UnitState.MovingToResource;
            _mover.MoveTo(_targetResource.Position);
        }

        private void HandleMovingToResource()
        {
            if (_mover.HasReachedDestination(_interactionDistance))
            {
                _targetResource.PickUp(_carryPoint);
                _currentState = UnitState.ReturningToDropOff;
                _mover.MoveTo(_dropOffPoint.position);
            }
        }

        private void HandleReturningToDropOff()
        {
            if (_mover.HasReachedDestination(_interactionDistance))
            {
                _targetResource.Collect();
                _targetResource = null;
                _currentState = UnitState.Idle;

                ResourceDelivered?.Invoke(this);
            }
        }
    }
}
