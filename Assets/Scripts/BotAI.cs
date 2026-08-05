using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(RigidbodyMover))]
    [RequireComponent(typeof(RigidbodyRotator))]
    [RequireComponent(typeof(StepClimber))]
    public class BotAI : MonoBehaviour
    {
        [Header("Target & Distance")]
        [SerializeField] private Transform _target;
        [SerializeField] private float _stoppingDistance = 2.5f;

        [Header("Components settings")]
        [SerializeField] private RigidbodyMover _mover;
        [SerializeField] private RigidbodyRotator _rotator;
        [SerializeField] private StepClimber _stepClimber;

        private void FixedUpdate()
        {
            if (_target == null) 
                return;

            Vector3 directionToTarget = CalculateFlatDirection(transform.position, _target.position, out float flatDistance);

            if (directionToTarget == Vector3.zero) 
                return;

            _rotator.RotateTowardsDirection(directionToTarget);

            if (flatDistance > _stoppingDistance)
            {
                _mover.MoveInDirection(directionToTarget);
                _stepClimber.TryStep(directionToTarget);
            }
        }

        private Vector3 CalculateFlatDirection(Vector3 currentPosition, Vector3 targetPosition, out float distance)
        {
            Vector3 flatCurrent = new Vector3(currentPosition.x, 0f, currentPosition.z);
            Vector3 flatTarget = new Vector3(targetPosition.x, 0f, targetPosition.z);

            Vector3 direction = flatTarget - flatCurrent;
            distance = direction.magnitude;

            return distance > 0f ? direction / distance : Vector3.zero;
        }
    }
}
