using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private Transform _carryPoint;
        [SerializeField] private float _interactionDistance = 1.5f;

        private NavMeshAgent _agent;
        private IResource _targetResource;
        private IBase _homeBase;

        private UnitState _currentState = UnitState.Idle;

        public bool IsFree => _currentState == UnitState.Idle;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void AssignTask(IResource resource, IBase homeBase)
        {
            _targetResource = resource;
            _homeBase = homeBase;

            _targetResource.SetTargeted(true);
            _currentState = UnitState.MovingToResource;
            _agent.SetDestination(_targetResource.Position);
        }

        private void Update()
        {
            if (_currentState == UnitState.MovingToResource)
            {
                HandleMovingToResource();
            }
            else if (_currentState == UnitState.ReturningToBase)
            {
                HandleReturningToBase();
            }
        }

        private void HandleMovingToResource()
        {
            if (!PathPending() && _agent.remainingDistance <= _interactionDistance)
            {
                _targetResource.PickUp(_carryPoint);

                _currentState = UnitState.ReturningToBase;
                _agent.SetDestination(_homeBase.Position);
            }
        }

        private void HandleReturningToBase()
        {
            if (!PathPending() && _agent.remainingDistance <= _interactionDistance)
            {
                _targetResource.Collect();
                _targetResource = null;
                _homeBase.ReceiveResource();

                _currentState = UnitState.Idle;
            }
        }

        private bool PathPending() 
            => _agent.pathPending || _agent.pathStatus == NavMeshPathStatus.PathInvalid;
    }
}
